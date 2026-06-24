<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Regform.aspx.cs"
    Inherits="CRUDC.Regform" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Employee CRUD Operation</h2>


    <div>
        Name :
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvName"
            runat="server"
            ControlToValidate="txtName"
            ErrorMessage="Name Required"
            ForeColor="Red">
        </asp:RequiredFieldValidator>
    </div>

    <br />

    <div>
        Email :
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvEmail"
            runat="server"
            ControlToValidate="txtEmail"
            ErrorMessage="Email Required"
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <asp:RegularExpressionValidator
            ID="revEmail"
            runat="server"
            ControlToValidate="txtEmail"
            ValidationExpression="\w+([-.+']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ErrorMessage="Invalid Email"
            ForeColor="Red">
        </asp:RegularExpressionValidator>
    </div>

    <br />

    <div>
        Salary :
        <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvSalary"
            runat="server"
            ControlToValidate="txtSalary"
            ErrorMessage="Salary Required"
            ForeColor="Red">
        </asp:RequiredFieldValidator>
    </div>

    <br />

    <div>
        <asp:Button ID="btnSave"
            runat="server"
            Text="Save"
            OnClick="btnSave_Click" />
    </div>

    <br /><br />

    <asp:GridView ID="GridView1"
        runat="server"
        AutoGenerateColumns="False"
        OnRowCommand="GridView1_RowCommand">

        <Columns>

            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Salary" HeaderText="Salary" />

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>

                    <asp:LinkButton ID="lnkEdit"
                        runat="server"
                        Text="Edit"
                        CommandName="EditEmp"
                        CommandArgument='<%# Eval("Id") %>'
                        CausesValidation="false">
                    </asp:LinkButton>

                    |

                    <asp:LinkButton ID="lnkDelete"
                        runat="server"
                        Text="Delete"
                        CommandName="DeleteEmp"
                        CommandArgument='<%# Eval("Id") %>'
                        CausesValidation="false"
                        OnClientClick="return confirm('Delete Record?');">
                    </asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</asp:Content>