using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Messages.RequestModels
{
    public class GetPatientMessageHistoryRequestModel
    {

        public int PatientId { get; set; }
        public int MsgId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int UserId { get; set; }
        public int UserTimeZone { get; set; }
    }
}
