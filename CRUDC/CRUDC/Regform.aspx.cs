using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CRUDC
{
    public partial class Regform : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["mconn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        void BindGrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee", conStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            if (txtName.Text.Trim() == "")
            {
                return;
            }

            if (txtEmail.Text.Trim() == "")
            {
                return;
            }

            if (txtSalary.Text.Trim() == "")
            {
                return;
            }

            decimal sal;

            if (!decimal.TryParse(txtSalary.Text, out sal))
            {
                return;
            }

            //lblMsg.Text = "";

            //if (string.IsNullOrEmpty(txtName.Text))
            //{
            //    lblMsg.Text = "Enter Name";
            //    return;
            //}

            //if (string.IsNullOrEmpty(txtEmail.Text))
            //{
            //    lblMsg.Text = "Enter Email";
            //    return;
            //}

            //if (string.IsNullOrEmpty(txtSalary.Text))
            //{
            //    lblMsg.Text = "Enter Salary";
            //    return;
            //}

            if (string.IsNullOrEmpty(txtName.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert('Enter Name');", "alert", true);
                return;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert('Enter Email');", "alert", true);
                return;
              
            }

            if (string.IsNullOrEmpty(txtSalary.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert('Enter Salary');", "alert", true);
                return;             
            }

            SqlConnection con = new SqlConnection(conStr);

            con.Open();

            if (ViewState["Id"] == null)
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Employee(Name,Email,Salary) VALUES(@Name,@Email,@Salary)", con);

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);

                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Employee SET Name=@Name,Email=@Email,Salary=@Salary WHERE Id=@Id", con);

                cmd.Parameters.AddWithValue("@Id", ViewState["Id"]);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);

                cmd.ExecuteNonQuery();
            }

            con.Close();

            ViewState["Id"] = null;

            txtName.Text = "";
            txtEmail.Text = "";
            txtSalary.Text = "";

            BindGrid();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditEmp")
            {
                ViewState["Id"] = id;

                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT * FROM Employee WHERE Id=" + id, conStr);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtSalary.Text = dt.Rows[0]["Salary"].ToString();
                }
            }
            else if (e.CommandName == "DeleteEmp")
            {
                SqlConnection con = new SqlConnection(conStr);

                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Employee WHERE Id=@Id", con);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();

                con.Close();

                BindGrid();
            }
        }
    }
}