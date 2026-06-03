using StudentManagement.StudentManagement.Logic;
using StudentManagement.StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagement.StudentManagement.UI
{
    public partial class StudentForm : System.Web.UI.Page
    {
        private StudentManager _manager = new StudentManager();
        private Student student = new Student();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string rollno = Request.QueryString["Rollno"];
                int id;


                if (!string.IsNullOrEmpty(rollno) && int.TryParse(rollno, out id))
                {
                    UpdateStudentData(id);
                    TextBox2.ReadOnly = true;
                }

            }
        }

        protected void UpdateStudentData(int rollno)
        {

            var StudentData = _manager.DataToForm(rollno);
            {
                TextBox1.Text = StudentData.Rows[0]["Name"].ToString();
                TextBox2.Text = StudentData.Rows[0]["Rollno"].ToString();
                DropDownList1.Text = StudentData.Rows[0]["Department"].ToString();
                DropDownList2.Text = StudentData.Rows[0]["Year"].ToString();
                txtDob.Text = Convert.ToDateTime(StudentData.Rows[0]["DOB"]).ToString("yyyy-MM-dd");
                gender.Text = StudentData.Rows[0]["Gender"].ToString();
                DropDownList3.Text = StudentData.Rows[0]["Country"].ToString();
                CommentsTextBox.Text = StudentData.Rows[0]["Address"].ToString();

            }
        }

        protected void btn_cancel(object sender, EventArgs e)
        {
            TextBox1.Text = student.Name;
            TextBox2.Text = student.Rollno.ToString();

            if (DropDownList1.Items.FindByValue(student.Year) != null)
                DropDownList1.SelectedValue = student.Year;


            gender.Text = student.Gender;

            if (DropDownList2.Items.FindByValue(student.Department) != null)
                DropDownList2.SelectedValue = student.Department;

            txtDob.Text = Convert.ToDateTime(student.DOB).ToString("yyyy-MM-dd");

            if (DropDownList3.Items.FindByValue(student.Country) != null)
                DropDownList3.SelectedValue = student.Country;

            CommentsTextBox.Text = student.Address;

        }




        protected async void btn_submit(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                Name = TextBox1.Text,
                Rollno = Convert.ToInt32(TextBox2.Text),
                Department = DropDownList1.SelectedValue,
                Year = DropDownList2.SelectedValue,
                Gender = gender.SelectedValue,
                DOB = Convert.ToDateTime(txtDob.Text),
                Country = DropDownList3.SelectedValue,
                Address = CommentsTextBox.Text
            };


            //StudentManagerChannel manager = new StudentManagerChannel();
            //await manager.AddStudentAsync(student);



            string result = await _manager.SaveStudentAsync(student);
            if (result.Contains("Duplicate"))
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('{result}');", true);
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                    $"alert('{result}'); window.location='StudentTable.aspx';", true);
            }

            //Response.Redirect("StudentDatatable.aspx", false);
            //Context.ApplicationInstance.CompleteRequest();
        }
    }
}