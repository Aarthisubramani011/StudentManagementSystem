using StudentManagement.StudentManagement.Data;
using StudentManagement.StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Threading.Tasks;
using System.Web;

namespace StudentManagement.StudentManagement.Logic
{
    public class StudentManager
    {
        private StudentData _studentData = new StudentData();

        public DataTable GetAllStudents()
        {
            return _studentData.DisplayTable();
        }

        public void DeleteStudentAsync(int rollno)
        {
             _studentData.DeleteStudentAsync(rollno);
        }

        public DataTable DataToForm(int rollno)
        {
            return _studentData.DataToForm(rollno);
        }

        public async Task<string> SaveStudentAsync(Student student)
        {
            int exists = await _studentData.CheckStudentExistsAsync(student.Rollno);

            if (exists > 0)
            {
                return "Duplicate RollNo Found";
            }

            await AddStudentAsync(student);
            return "Student Added Successfully";
        }

        public async Task AddStudentAsync(Student student)
        {
            await _studentData.AddAsync(student);
            //await _channel.Writer.WriteAsync(student);
        }
    }
}