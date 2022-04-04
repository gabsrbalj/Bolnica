using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class PatientRepository
    {
        static string constr = @"Data Source=DESKTOP-R80D4UH\SQLEXPRESS;Initial Catalog=Medical;Integrated Security=True";

        static List<PatientModel> patient = new List<PatientModel>();
        public async Task<List<PatientModel>> GetAllPatients()
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Patient", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        PatientModel patmod = new PatientModel();
                        patmod.PatientID = reader.GetGuid(0);
                        patmod.FirstName = reader.GetString(1);
                        patmod.LastName = reader.GetString(2);
                        patmod.Diagnosis = reader.GetString(3);
                        patmod.IdentificationNumber = reader.GetString(4);
                        patmod.CreatedAt = reader.GetDateTime(5);
                        patmod.UpdatedAt = reader.GetDateTime(6);
                        patmod.DeletedAt = reader.GetDateTime(7);

                        patient.Add(patmod);

                    }

                }
                return patient;
                connection.Close();
            }
        }
    }
}
