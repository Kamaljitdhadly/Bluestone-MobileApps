using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Messages.ViewModels
{
    public class GetInboxMessageListViewModel
    {
        public int RowId { get; set; }
        public int Msg_Id { get; set; }
        public int About { get; set; }
        public string Subject { get; set; }
        public bool Urgent { get; set; }
        public string Body { get; set; }
        public string Msg_Subject { get; set; }
        public int StatusId { get; set; }
        public string How_long { get; set; }
        public DateTime? Msg_TimeStamp { get; set; }
        public string MsgTimeStamp { get; set; }
        public string Patient_Name { get; set; }
        public string From { get; set; }
        public string SentTo { get; set; }
        public string From_Name { get; set; }
        public string From_User_Type { get; set; }
        public string Msg_Status_Icon { get; set; }
        public bool Urgent_Ind { get; set; }
        public int Order_Ind { get; set; }
        public bool IsRead { get; set; }
        public string Status { get; set; }
        public string MessageCssColor { get; set; }
        public int InrIcon { get; set; }
        public int TotalMessages { get; set; }
        public string Location_Name { get; set; }
        public string TypeIconImage { get; set; }
        public bool IsInfoReqEmailSend { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public bool IsMsgInGroup { get; set; }
        public string GroupNameIds { get; set; }
        public string GroupNameBanner { get; set; }
    }
}
