using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Patients.RequestModels
{
    public class GetPatientListRequestModel
    {
        public int UserId { get; set; }
        public bool Inactive { get; set; }
        public int PatientsAccessType { get; set; }
    }
}
