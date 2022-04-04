using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class MedicalReferralRepository
    {
        static string constr = @"Data Source=DESKTOP-R80D4UH\SQLEXPRESS;Initial Catalog=Medical;Integrated Security=True";

        static List<MedicalReferralModel> medicalReferral = new List<MedicalReferralModel>();
        public async Task<List<MedicalReferralModel>> GetAllMedicalReferrals()
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM MedicalReferral", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        MedicalReferralModel medicalReferralModel = new MedicalReferralModel();
                        medicalReferralModel.MedicalReferralID = reader.GetGuid(0);
                        medicalReferralModel.Diagnosis = reader.GetString(1);
                        medicalReferralModel.Department = reader.GetString(2);
                        medicalReferralModel.ReferralDate = reader.GetDateTime(3);
                        medicalReferralModel.CreatedAt = reader.GetDateTime(4);
                        medicalReferralModel.UpdatedAt = reader.GetDateTime(5);
                        medicalReferralModel.DeletedAt = reader.GetDateTime(6);

                        medicalReferral.Add(medicalReferralModel);

                    }

                }
                return medicalReferral;
                connection.Close();
            }
        }
    }
}
