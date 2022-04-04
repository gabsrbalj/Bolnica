using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class HospitalRepository
    {
        static string constr = @"Data Source=DESKTOP-R80D4UH\SQLEXPRESS;Initial Catalog=Medical;Integrated Security=True";

        static List<HospitalModel> hospital = new List<HospitalModel>();
        public async Task<List<HospitalModel>> ShowHospital()
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Hospital", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        HospitalModel hospitalModel = new HospitalModel();
                        hospitalModel.HospitalID = reader.GetGuid(0);
                        hospitalModel.HospitalName = reader.GetString(1);
                        hospitalModel.Address = reader.GetString(2);

                        hospital.Add(hospitalModel);

                    }

                }
                return hospital;
                connection.Close();
            }
        }
    }
}
