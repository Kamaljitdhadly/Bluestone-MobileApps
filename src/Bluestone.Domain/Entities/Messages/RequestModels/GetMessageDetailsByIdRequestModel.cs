using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Messages.RequestModels
{
    public class GetMessageDetailsByIdRequestModel
    {
        public int MessageId { get; set; }

        public bool ToolBarOption { get; set; }

        public int UserId { get; set; }

        public int UserTimezone { get; set; }

    }
}
