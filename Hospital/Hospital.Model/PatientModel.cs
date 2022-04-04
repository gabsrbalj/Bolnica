using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class PatientModel
    {
        public Guid PatientID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Diagnosis { get; set; }

        public string IdentificationNumber { get; set; }

        public string MedicalRecordNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }

    }
}
