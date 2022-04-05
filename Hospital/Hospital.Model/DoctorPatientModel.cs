using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class DoctorPatientModel
    {
        public Guid PatientID { get; set; }

        public  Guid DoctorID { get; set; }

        public int DoctorPatientID { get; set; }
    }
}
