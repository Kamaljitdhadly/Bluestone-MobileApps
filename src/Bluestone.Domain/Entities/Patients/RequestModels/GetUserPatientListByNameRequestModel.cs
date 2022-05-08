using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Patients.RequestModels
{
    public class GetUserPatientListByNameRequestModel
    {
        public int UserId { get; set; }
        public string PatientName { get; set; }
    }
}
