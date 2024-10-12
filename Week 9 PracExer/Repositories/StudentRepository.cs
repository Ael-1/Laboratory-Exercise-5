using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Week_9_PracExer.Models;

namespace Week_9_PracExer.Repositories
{
    public class StudentRepository
    {
        private readonly string connectionString = "Data Source=ael\\SQLEXPRESS;Initial Catalog=dboExample;User ID=sa;Password=123456;Encrypt=True;Trust Server Certificate=True";

        public List<Student> ReadStudents()
        {
            var students = new List<Student>();

            
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM [dboExample].[dbo].[tableStudent]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Student student = new Student();
                                student.id = reader.GetInt32(0);
                                student.first_name = reader.GetString(1);
                                student.last_name = reader.GetString(2);
                                student.address = reader.GetString(3);
                                student.phone = reader.GetString(4);

                                students.Add(student);
                            }
                        }
                    }
                }
            

            return students;
        }

        public void createStudent(Student student)
        {
            
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO [dboExample].[dbo].[tableStudent]" +
                        " (first_name, last_name, address, phone) VALUES " +
                        "(@first_name, @last_name, @address, @phone)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@first_name", student.first_name);
                        command.Parameters.AddWithValue("@last_name", student.last_name);
                        command.Parameters.AddWithValue("@address", student.address);
                        command.Parameters.AddWithValue("@phone", student.phone);

                        command.ExecuteNonQuery();
                    }
                }
        }
    }
}
