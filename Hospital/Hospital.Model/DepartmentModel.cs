using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class DepartmentModel
    {
        public Guid departmentID { get; set; }

        public string departmentName { get; set; }

        public int hospitalFloor { get; set; }

        public string telephoneNumber { get; set; }

        public Guid hospitalID { get; set; }

        public string specialization { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime deletedAt  { get; set; }
    }
}
