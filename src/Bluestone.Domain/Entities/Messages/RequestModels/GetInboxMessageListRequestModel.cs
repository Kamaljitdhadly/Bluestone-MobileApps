using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Messages.RequestModels
{
    public class GetInboxMessageListRequestModel
    {
        public int UserId { get; set; }
        public int Status { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string FilterInbox { get; set; }
        public int PatientId { get; set; }
        public DateTime? TStamp { get; set; }
        public int ViewId { get; set; }
        public bool UrgentOnly { get; set; }
        public bool HavingOrdersAttached { get; set; }
        public int TeamId { get; set; }
        public string SortBy { get; set; }
        public bool IsCommunitySearch { get; set; }
        public bool IncludeFiledSystemMessages { get; set; }
    }
}
