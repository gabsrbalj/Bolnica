using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hospital.WebApi.Controllers
{
    public class MedicalReferralController : ApiController
    {
        static List<MedicalReferralModel> medicalReferral = new List<MedicalReferralModel>();

        [HttpGet]
        [Route("api/MedicalReferrals")]
        public async Task<HttpResponseMessage> GetAllMedicalReferrals()
        {
            MedicalReferralService service = new MedicalReferralService();

            medicalReferral = await service.GetAllMedicalReferrals();

            if (medicalReferral != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, medicalReferral);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Medical Referral Not Found");
            }

        }
    }
}
