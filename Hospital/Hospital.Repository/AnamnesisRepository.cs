using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class AnamnesisRepository
    {
        static string constr = @"Data Source=DESKTOP-R80D4UH\SQLEXPRESS;Initial Catalog=Medical;Integrated Security=True";

        static List<AnamnesisModel> anamnesis = new List<AnamnesisModel>();
        public async Task<List<AnamnesisModel>> GetAllAnamnesis()
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Anamnesis", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        AnamnesisModel anamnesisModel = new AnamnesisModel();
                        anamnesisModel.AnamnesisID = reader.GetGuid(0);
                        anamnesisModel.Diagnosis = reader.GetString(1);
                        anamnesisModel.CreatedAt = reader.GetDateTime(2);
                        anamnesisModel.UpdatedAt = reader.GetDateTime(3);
                        anamnesisModel.DeletedAt = reader.GetDateTime(4);

                        anamnesis.Add(anamnesisModel);

                    }

                }
                return anamnesis;
                connection.Close();
            }
        }
    }
}
