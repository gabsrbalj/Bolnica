using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class PatientService
    {
        public async Task<List<PatientModel>> GetAllPatientsAsync()
        {

            PatientRepository patrepo = new PatientRepository();
            return await patrepo.GetAllPatientsAsync();

        }

        public async Task<List<PatientModel>> GetPatientAsync(int id)
        {

            PatientRepository patrepo = new PatientRepository();
            return await patrepo.GetPatientAsync(id);

        }

        public async Task<PatientModel> InsertPatientAsync(PatientModel patient)
        {
            PatientRepository insertPatient = new PatientRepository();

            return await insertPatient.PutPatientAsync(patient);
        }
    }
}
