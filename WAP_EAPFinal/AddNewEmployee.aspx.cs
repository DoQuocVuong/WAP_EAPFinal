using System;

namespace Application
{
    public partial class AddNewEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtEmpID.Text = "";
                txtName.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                lblMsg.Text = "";
                txtEmpID.Focus();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Adding New Employee Records  

            if ((txtEmpID.Text != "") || (txtName.Text != "") || (txtEmail.Text != "") || (txtPhone.Text != ""))
            {
                try
                {
                    MyService.Employee employee = new MyService.Employee();
                    employee.EmpID = txtEmpID.Text;
                    employee.Name = txtName.Text;
                    employee.Email = txtEmail.Text;
                    employee.Phone = txtPhone.Text;
                    employee.Gender = rbtnGender.SelectedItem.Text;

                    MyService.EmployeeServiceClient client = new MyService.EmployeeServiceClient();
                    lblMsg.Text = "Employee ID: " + employee.EmpID + ", " + client.AddEmployyeeRecord(employee);
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Employee ID must be unique! ";
                }


            }
            else
            {

                lblMsg.Text = "All fields are mandatory! ";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }


        }

        protected void bntReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtEmpID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            lblMsg.Text = "";
            txtEmpID.Focus();
        }
    }
}