using StudentManagement.StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StudentManagement.StudentManagement.Data
{
    public class StudentData
    {
        private static string cs = "Data Source=.;Initial Catalog=StudentDatabase2;User ID=sa;Password=kala@2005;Encrypt=False";

        public DataTable DisplayTable()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT * FROM StudentDetails";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public void DeleteStudentAsync(int rollno)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "DELETE FROM StudentDetails WHERE Rollno = @Rollno";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Rollno", rollno);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable DataToForm(int rollno)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT * FROM StudentDetails WHERE RollNo=@RollNo";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = rollno;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public async Task<int> CheckStudentExistsAsync(int rollno) 
        {
            return 0;
        }

        public async Task AddAsync(Model.Student student)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                await conn.OpenAsync();

                string query = @"INSERT INTO StudentDetails
                        (
                            Rollno,
                            Name,
                            Department,
                            Year,
                            Gender,
                            DOB,
                            Country,
                            Address
                        )
                        VALUES
                        (
                            @Rollno,
                            @Name,
                            @Department,
                            @Year,
                            @Gender,
                            @DOB,
                            @Country,
                            @Address
                        )";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Rollno", student.Rollno);
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Department", student.Department);
                    cmd.Parameters.AddWithValue("@Year", student.Year);
                    cmd.Parameters.AddWithValue("@Gender", student.Gender);
                    cmd.Parameters.AddWithValue("@DOB", student.DOB);
                    cmd.Parameters.AddWithValue("@Country", student.Country);
                    cmd.Parameters.AddWithValue("@Address", student.Address);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateStudentDataAsync(Student student)
        {
            

            using (SqlConnection con = new SqlConnection(cs))
            {
                await con.OpenAsync();
                string query = @"
                                UPDATE StudentDetails
                                SET 
                                    Name = @Name,
                                    Department = @Department,
                                    Year = @Year,
                                    Gender = @Gender,
                                    DOB = @DOB,
                                    Country = @Country,
                                    Address = @Address
                                WHERE Rollno = @Rollno";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Department", student.Department);
                    cmd.Parameters.AddWithValue("@Year", student.Year);
                    cmd.Parameters.AddWithValue("@Gender", student.Gender);
                    cmd.Parameters.AddWithValue("@DOB", student.DOB);
                    cmd.Parameters.AddWithValue("@Country", student.Country);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@Rollno", student.Rollno);

                    await cmd.ExecuteNonQueryAsync();
                } 

                

            }
        }
    }
}