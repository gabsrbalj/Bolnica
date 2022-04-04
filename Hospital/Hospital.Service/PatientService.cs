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
        public async Task<List<PatientModel>> GetAllPatients(){

            PatientRepository patrepo = new PatientRepository();
            return await patrepo.GetAllPatients();

        }
    }
}
