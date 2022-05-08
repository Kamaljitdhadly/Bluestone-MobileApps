using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Messages.ViewModels
{
    public class GetMessageDetailsByIdViewModel
    {
        public int MessageId { get; set; }

        public string Body { get; set; }

        public bool Urgent { get; set; }

        public string How_Long { get; set; }

        public bool Isread { get; set; }

    }
}
