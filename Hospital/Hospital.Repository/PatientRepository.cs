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
        public async Task<List<PatientModel>> GetAllPatientsAsync()
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

                        PatientModel patientModel = new PatientModel();
                        patientModel.patientID = reader.GetGuid(0);
                        patientModel.firstName = reader.GetString(1);
                        patientModel.lastName = reader.GetString(2);
                        patientModel.diagnosis = reader.GetString(3);
                        patientModel.identificationNumber = reader.GetString(4);
                        patientModel.createdAt = reader.GetDateTime(5);
                        patientModel.updatedAt = reader.GetDateTime(6);
                        patientModel.deletedAt = reader.GetDateTime(7);

                        patient.Add(patientModel);

                    }

                    return patient;
                }
                else
                {
                    return null;
                }
               
                connection.Close();
            }
        }



        public async Task<List<PatientModel>> GetPatientAsync(int id)
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Patient  WHERE patientId={id}", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        PatientModel patientModel = new PatientModel();
                        patientModel.patientID = reader.GetGuid(0);
                        patientModel.firstName = reader.GetString(1);
                        patientModel.lastName = reader.GetString(2);
                        patientModel.diagnosis = reader.GetString(3);
                        patientModel.identificationNumber = reader.GetString(4);
                        patientModel.createdAt = reader.GetDateTime(5);
                        patientModel.updatedAt = reader.GetDateTime(6);
                        patientModel.deletedAt = reader.GetDateTime(7);

                        patient.Add(patientModel);

                    }

                    return patient;

                }
                else
                {
                    return null;
                }
               
                connection.Close();
            }
        }



        public async Task<PatientModel> PutPatientAsync(PatientModel patient)
        {
            //string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand($"INSERT INTO Patient (patientID, firstName, lastName, diagnosis, identificationNumber, medicalRecordNumber, createdAt) VALUES ({patient.patientID}, '{patient.firstName}', '{patient.lastName}','{patient.diagnosis}','{patient.identificationNumber}','{patient.medicalRecordNumber}','{patient.createdAt}');", connection);


            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            await adapter.InsertCommand.ExecuteNonQueryAsync();

            connection.Close();
            return patient;
        }








    }
}
