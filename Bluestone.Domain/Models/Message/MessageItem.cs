using System;
using System.Collections.Generic;
using System.Text;

namespace Bluestone.Domain.Models.Message
{
    public class MessageItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SenderName { get; set; }

        public string Description { get; set; }

        public string MessageType { get; set; }

        public string ImagePath { get; set; }

        public string Time { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string PictureUri { get; set; }

        public string DetailsUri { get; set; }

    }
}
