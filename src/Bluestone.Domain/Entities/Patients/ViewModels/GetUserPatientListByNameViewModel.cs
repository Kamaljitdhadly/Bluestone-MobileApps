using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Patients.ViewModels
{
    public class GetUserPatientListByNameViewModel
    {
        public string Facility { get; set; }
        public int FacilityId { get; set; }
        public DateTime? PatientDob { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
