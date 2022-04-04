using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class HospitalService
    {
        public async Task<List<HospitalModel>> ShowHospital()
        {

            HospitalRepository hospitalRepository = new HospitalRepository();
            return await hospitalRepository.ShowHospital();

        }
    }
}
