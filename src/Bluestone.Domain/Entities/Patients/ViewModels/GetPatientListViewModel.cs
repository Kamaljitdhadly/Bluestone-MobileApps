using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Patients.ViewModels
{
    public class GetPatientListViewModel
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddletName { get; set; }
        public DateTime? PatientDOB { get; set; }
        public string LocationName { get; set; }
    }
}
