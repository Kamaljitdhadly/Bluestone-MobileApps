using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Messages.RequestModels
{
    public class GetMessageTypeListByUserRequestModel
    {
        public int UserId { get; set; }
        public int PatientId { get; set; }
    }
}
