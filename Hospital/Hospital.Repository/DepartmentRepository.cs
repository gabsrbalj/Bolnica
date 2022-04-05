using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class DepartmentRepository
    {
        static string constr = @"Data Source=DESKTOP-R80D4UH\SQLEXPRESS;Initial Catalog=Medical;Integrated Security=True";

        static List<DepartmentModel> department = new List<DepartmentModel>();
        public async Task<List<DepartmentModel>> GetAllDepartmentsAsync()
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Department", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        DepartmentModel departmentModel = new DepartmentModel();
                        departmentModel.departmentID = reader.GetGuid(0);
                        departmentModel.departmentName = reader.GetString(1);
                        departmentModel.hospitalFloor = reader.GetInt32(2);
                        departmentModel.telephoneNumber = reader.GetString(3);
                        departmentModel.hospitalID = reader.GetGuid(4);
                        departmentModel.specialization = reader.GetString(5);
                        departmentModel.createdAt = reader.GetDateTime(6);
                        departmentModel.updatedAt = reader.GetDateTime(7);
                        departmentModel.deletedAt = reader.GetDateTime(8);

                        department.Add(departmentModel);

                    }

                    return department;

                }
                else
                {
                    return null;
                }
               
                connection.Close();
            }
        }

        public async Task<List<DepartmentModel>> GetDepartmentAsync(int id)
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Department WHERE departmentID={id};", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        DepartmentModel departmentModel = new DepartmentModel();
                        departmentModel.departmentID = reader.GetGuid(0);
                        departmentModel.departmentName = reader.GetString(1);
                        departmentModel.hospitalFloor = reader.GetInt32(2);
                        departmentModel.telephoneNumber = reader.GetString(3);
                        departmentModel.hospitalID = reader.GetGuid(4);
                        departmentModel.specialization = reader.GetString(5);
                        departmentModel.createdAt = reader.GetDateTime(6);
                        departmentModel.updatedAt = reader.GetDateTime(7);
                        departmentModel.deletedAt = reader.GetDateTime(8);

                        department.Add(departmentModel);

                    }

                    return department;

                }
                else
                {
                    return null;
                }

                connection.Close();
            }
        }

    }
}
