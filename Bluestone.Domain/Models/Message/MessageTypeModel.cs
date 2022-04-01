using System;
using System.Collections.Generic;
using System.Text;

namespace Bluestone.Domain.Models.Message
{
    public class MessageTypeModel
    {
        public int MessageTypeId { get; set; }
        public string MessageTypeName { get; set; }
        public string MessageDescription { get; set; }
    }
}
