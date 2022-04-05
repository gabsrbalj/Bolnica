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
    public class PatientController : ApiController
    {

        static List<PatientModel> patient = new List<PatientModel>();

        [HttpGet]
        [Route("api/ShowAllPatients")]
        public async Task<HttpResponseMessage> GetAllPatients()
        {
            PatientService service = new PatientService();
            
            patient = await service.GetAllPatientsAsync();

            if (patient != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Patient Not Found");
            }
           
        }


        [HttpGet]
        [Route("api/getbyid")]
        public async Task<HttpResponseMessage> GetPatientAsync(int id)
        {
            PatientService service = new PatientService();

            patient = await service.GetPatientAsync(id);

            if (patient != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Patient Not Found");
            }

        }

        
        [HttpPost]
        [Route("api/insertPatient")]
        public async Task<HttpResponseMessage> PostAsync(PatientModel patient)
        { 

            PatientService service = new PatientService();
            PatientModel newPatient = new PatientModel();

            newPatient.patientID = Guid.NewGuid();
            newPatient = await service.InsertPatientAsync(patient);

            PatientModelRest newPatientRest = new PatientModelRest();
            newPatientRest.patientID = newPatient.patientID;
            newPatientRest.firstName = newPatient.firstName;
            newPatientRest.lastName = newPatient.lastName;
            newPatientRest.diagnosis = newPatient.diagnosis;
            newPatientRest.identificationNumber = newPatient.identificationNumber;
            newPatientRest.medicalRecordNumber = newPatient.medicalRecordNumber;
            newPatientRest.createdAt = newPatient.createdAt;
           

            return Request.CreateResponse(HttpStatusCode.OK, newPatientRest);

        }

        [Route("api/updatePatient")]
        public async Task<HttpResponseMessage> PutAsync(int id, PatientModel patient)
        {

            PatientService service = new PatientService();
            PatientModel update = new PatientModel();

            update = await service.UpdatePatientAsync(id, patient);

            if (update != null)
            {
                PatientModelRest newPatient = new PatientModelRest();
                newPatient.firstName = patient.firstName;
                newPatient.lastName = patient.lastName;
                newPatient.diagnosis = patient.diagnosis;
                newPatient.identificationNumber = patient.identificationNumber;
                newPatient.medicalRecordNumber = patient.medicalRecordNumber;
                newPatient.updatedAt = patient.updatedAt;


                return Request.CreateResponse(HttpStatusCode.OK,newPatient);
            }



            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Patient does not exist in database.");
            }

        }


        [Route("api/deletePatient")]
        public async Task<HttpResponseMessage> DeleteAsync(int id, PatientModel patient)
        {

            PatientService service = new PatientService();
            PatientModel delete = new PatientModel();

            delete = await service.UpdatePatientAsync(id, patient);

            if (delete != null)
            {
        
                return Request.CreateResponse(HttpStatusCode.OK, "From now, this patient is inactive in database.");
            }



            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Patient does not exist in database.");
            }

        }



    }
}
