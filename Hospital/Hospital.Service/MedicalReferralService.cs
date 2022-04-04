using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class MedicalReferralService
    {
        public async Task<List<MedicalReferralModel>> GetAllMedicalReferrals()
        {

            MedicalReferralRepository medicalReferralRepository = new MedicalReferralRepository();
            return await medicalReferralRepository.GetAllMedicalReferrals();

        }
    }
}
