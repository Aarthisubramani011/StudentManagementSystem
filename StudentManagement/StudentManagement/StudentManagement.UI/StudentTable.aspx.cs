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
    public partial class StudentTable : System.Web.UI.Page
    {
        private StudentManager _manager = new StudentManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            GridView1.DataSource = _manager.GetAllStudents();
            GridView1.DataBind();
        }

        protected void Addform(object sender, EventArgs e)
        {
            Response.Redirect("StudentForm.aspx", true);

        }

        protected void EditStudentClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect("StudentForm.aspx?Rollno=" + id);
            BindGrid();
        }

        protected void DeleteStudentClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.CommandArgument);
            _manager.DeleteStudentAsync(id);

            BindGrid();
        }
    }
}