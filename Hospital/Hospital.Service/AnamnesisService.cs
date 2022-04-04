using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class AnamnesisService
    {
        public async Task<List<AnamnesisModel>> GetAllAnamnesis()
        {

            AnamnesisRepository anamnesisRepository = new AnamnesisRepository();
            return await anamnesisRepository.GetAllAnamnesis();

        }
    }
}
