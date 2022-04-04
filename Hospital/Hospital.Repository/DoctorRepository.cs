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

                        DoctorModel doctorModel = new DoctorModel();
                        doctorModel.DoctorID = reader.GetGuid(0);
                        doctorModel.FirstName = reader.GetString(1);
                        doctorModel.LastName = reader.GetString(2);
                        doctorModel.TelephoneNumber = reader.GetString(3);
                        doctorModel.Email = reader.GetString(4);
                        doctorModel.DoctorPassword = reader.GetString(5);
                        doctorModel.CreatedAt = reader.GetDateTime(6);
                        doctorModel.DepartmentID = reader.GetGuid(7);

                        doctor.Add(doctorModel);
               
                    }

                }
                return doctor;
                connection.Close();
            }
        }
    }
}
