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

            doctorList = await service.GetDoctorsAsync();
            if(doctor != null)
            {
                List<DoctorModelRest> doctorMapped = new List<DoctorModelRest>();

                foreach(DoctorModel doctor in doctorList)
                {
                    DoctorModelRest doctorRest = new DoctorModelRest
                    {
                        doctorID = doctor.doctorID,
                        firstName = doctor.firstName,
                        lastName = doctor.lastName,
                        telephoneNumber = doctor.telephoneNumber,
                        email = doctor.email,
                        departmentID = doctor.departmentID
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



        [HttpGet]
        [Route("api/values/getbyid")]
        public async Task<HttpResponseMessage> GetDoctorAsync(int id)
        {
            DoctorService service = new DoctorService();

            List<DoctorModel> doctorList = new List<DoctorModel>();

            doctorList = await service.GetDoctorsAsync();
            if (doctor != null)
            {
                List<DoctorModelRest> doctorMapped = new List<DoctorModelRest>();

                foreach (DoctorModel doctor in doctorList)
                {
                    DoctorModelRest doctorRest = new DoctorModelRest
                    {
                        doctorID = doctor.doctorID,
                        firstName = doctor.firstName,
                        lastName = doctor.lastName,
                        telephoneNumber = doctor.telephoneNumber,
                        email = doctor.email,
                        departmentID = doctor.departmentID
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
