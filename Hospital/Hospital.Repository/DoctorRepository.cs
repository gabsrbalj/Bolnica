using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class DoctorRepository
    {
        static string constr = @"Data Source=DESKTOP-R80D4UH\SQLEXPRESS;Initial Catalog=Medical;Integrated Security=True";

        static List<DoctorModel> doctor = new List<DoctorModel>();
        public async Task<List<DoctorModel>> GetDoctors()
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Doctor", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        DoctorModel docmod = new DoctorModel();
                        docmod.DoctorID = reader.GetGuid(0);
                        docmod.FirstName = reader.GetString(1);
                        docmod.LastName = reader.GetString(2);
                        docmod.TelephoneNumber = reader.GetString(3);
                        docmod.Email = reader.GetString(4);
                        docmod.DoctorPassword = reader.GetString(5);
                        docmod.CreatedAt = reader.GetDateTime(6);
                        docmod.DepartmentID = reader.GetGuid(7);

                        doctor.Add(docmod);
               
                    }

                }
                return doctor;
                connection.Close();
            }
        }
    }
}
