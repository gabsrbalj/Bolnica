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
    public class DoctorController : ApiController
    {
        

        static List<DoctorModel> doctor = new List<DoctorModel>();

        [HttpGet]
        [Route("api/GetAllDoctors")]
       
        public async Task<HttpResponseMessage> GetDoctors()
        {
            DoctorService service = new DoctorService();

            List<DoctorModel> doctorList = new List<DoctorModel>();

            doctorList = await service.GetDoctors();
            if(doctor != null)
            {
                List<DoctorModelRest> doctorMapped = new List<DoctorModelRest>();

                foreach(DoctorModel doctor in doctorList)
                {
                    DoctorModelRest doctorRest = new DoctorModelRest
                    {
                        DoctorID = doctor.DoctorID,
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        TelephoneNumber = doctor.TelephoneNumber,
                        Email = doctor.Email,
                        DepartmentID = doctor.DepartmentID
                    };
                    doctorMapped.Add(doctorRest);
                }
                return Request.CreateResponse(HttpStatusCode.OK, doctorMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Doctor Not Found!");
            }
           
        }

       

       
    }
}
