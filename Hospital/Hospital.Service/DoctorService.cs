using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Repository;

namespace Hospital.Service
{
    public class DoctorService
    {
        public async Task<List<DoctorModel>> GetDoctors()
        {
            DoctorRepository doctorRepository = new DoctorRepository();
            return await doctorRepository.GetDoctors();
        }
    }
}
