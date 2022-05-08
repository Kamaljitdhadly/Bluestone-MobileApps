using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Facilities.RequestModels
{
    public class GetFacilityListRequestModel
    {
        public int UserId { get; set; }
        public bool InActive { get; set; }
        public int FacilityAccessType { get; set; }
    }
}
