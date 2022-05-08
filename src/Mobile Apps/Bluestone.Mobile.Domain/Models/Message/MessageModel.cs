using Bluestone.Mobile.Domain.Models.Identity;
using Bluestone.Mobile.Domain.Models.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bluestone.Mobile.Domain.Models.Message
{
    public class MessageModel
    {
        public int MessageId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string MessageCssColor { get; set; }
        public bool Urgent { get; set; }
        public DateTime? Timestamp { get; set; }
        public string How_Long { get; set; }
        public bool IsRead { get; set; }
        public bool InrIcon { get; set; }
        public PatientModel Patient { get; set; }
        public UserModel Sender { get; set; }
        public MessageTypeModel MessageType { get; set; }

    }

}
