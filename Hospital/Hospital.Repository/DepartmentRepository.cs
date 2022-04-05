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
        public async Task<List<DepartmentModel>> GetAllDepartments()
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
                        departmentModel.DepartmentID = reader.GetGuid(0);
                        departmentModel.DepartmentName = reader.GetString(1);
                        departmentModel.HospitalFloor = reader.GetInt32(2);
                        departmentModel.TelephoneNumber = reader.GetString(3);
                        departmentModel.HospitalID = reader.GetGuid(4);
                        departmentModel.Specialization = reader.GetString(5);
                        departmentModel.CreatedAt = reader.GetDateTime(6);
                        departmentModel.UpdatedAt = reader.GetDateTime(7);
                        departmentModel.DeletedAt = reader.GetDateTime(8);

                        department.Add(departmentModel);

                    }

                }
                return department;
                connection.Close();
            }
        }
    }
}
