using CRUDMVCs.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace CRUDMVCs.Controllers
{
    public class EmployeeController : Controller
    {
        string conStr =
        ConfigurationManager.ConnectionStrings["mconn"].ConnectionString;
        public ActionResult Index(int id = 0)
        {
            Employee emp = new Employee();

            if (id > 0)
            {
                SqlConnection con = new SqlConnection(conStr);

                SqlCommand cmd = new SqlCommand(
                "select * from Employee where Id=@Id", con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    emp.Id = (int)dr["Id"];
                    emp.Name = dr["Name"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Salary = (decimal)dr["Salary"];
                }

                con.Close();
            }


            ViewBag.EmployeeList = GetEmployees();

            return View(emp);
        }

        [HttpPost]
        public ActionResult Save(Employee emp)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.EmployeeList = GetEmployees();

                return View("Index", emp);
            }

            //if (emp.Name == "")
            //{
            //    ViewBag.NameError = "Enter Name";
            //}


            //if (emp.Email == "")
            //{
            //    ViewBag.EmailError = "Enter Email";
            //}


            //if (emp.Email != "" && !emp.Email.Contains("@"))
            //{
            //    ViewBag.EmailError = "Invalid Email";
            //}


            //if (emp.Salary == 0)
            //{
            //    ViewBag.SalaryError = "Enter Salary";
            //}


            //if (ViewBag.NameError != null ||
            //   ViewBag.EmailError != null ||
            //   ViewBag.SalaryError != null)
            //{
            //    ViewBag.EmployeeList = GetEmployees();

            //    return View("Index", emp);
            //}


            SqlConnection con = new SqlConnection(conStr);

            con.Open();


            if (emp.Id == 0)
            {
                SqlCommand cmd = new SqlCommand(
                "insert into Employee(Name,Email,Salary) values(@Name,@Email,@Salary)",
                con);

                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);

                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand(
                "update Employee set Name=@Name,Email=@Email,Salary=@Salary where Id=@Id",
                con);

                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);

                cmd.ExecuteNonQuery();
            }


            con.Close();


            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            SqlConnection con = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand(
            "delete from Employee where Id=@Id", con);

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            return RedirectToAction("Index");
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();

            SqlConnection con = new SqlConnection(conStr);

            SqlCommand cmd =
            new SqlCommand("select * from Employee", con);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                list.Add(new Employee
                {
                    Id = (int)dr["Id"],
                    Name = dr["Name"].ToString(),
                    Email = dr["Email"].ToString(),
                    Salary = (decimal)dr["Salary"]
                });
            }


            con.Close();

            return list;
        }
    }
}