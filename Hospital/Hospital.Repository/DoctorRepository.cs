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
        public async Task<List<DoctorModel>> GetDoctorsAsync()
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
                        doctorModel.doctorID = reader.GetGuid(0);
                        doctorModel.firstName = reader.GetString(1);
                        doctorModel.lastName = reader.GetString(2);
                        doctorModel.telephoneNumber = reader.GetString(3);
                        doctorModel.email = reader.GetString(4);
                        doctorModel.doctorPassword = reader.GetString(5);
                        doctorModel.createdAt = reader.GetDateTime(6);
                        doctorModel.departmentID = reader.GetGuid(7);

                        doctor.Add(doctorModel);
               
                    }

                }
                return doctor;
                connection.Close();
            }
        }



        public async Task<List<DoctorModel>> GetDoctorAsync(int id)
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Doctor WHERE doctorId={id}", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        DoctorModel docmod = new DoctorModel();
                        docmod.doctorID = reader.GetGuid(0);
                        docmod.firstName = reader.GetString(1);
                        docmod.lastName = reader.GetString(2);
                        docmod.telephoneNumber = reader.GetString(3);
                        docmod.email = reader.GetString(4);
                        docmod.doctorPassword = reader.GetString(5);
                        docmod.createdAt = reader.GetDateTime(6);
                        docmod.departmentID = reader.GetGuid(7);

                        doctor.Add(docmod);


                    }

                    return doctor;

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
