using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Messages.ViewModels
{
    public class GetMessageHistoryViewModel
    {
        public List<PatientMessagesHistory> Messages { get; set; }
        public List<PatientMessagesHistoryGeneralOrder> GeneralOrders { get; set; }
    }

    public class GetPatientMessageHistoryViewModel
    {
        public int RowId { get; set; }
        public int Msgid { get; set; }
        public string From { get; set; }
        public DateTime? Date { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public int MsgCount { get; set; }
        public bool HasOrder { get; set; }
        public string MessageCssColor { get; set; }
        public bool Urgent { get; set; }
        public bool IsFaxNotification { get; set; }
        public int MsgTypeId { get; set; }
        public string Typecode { get; set; }
        public string Icon { get; set; }
        public string StatusName { get; set; }
        public List<PatientMessagesHistoryGeneralOrder> GeneralOrders { get; set; }
    }

    public class PatientMessagesHistory
    {
        public int RowId { get; set; }
        public int Msgid { get; set; }
        public string From { get; set; }
        public DateTime? Date{ get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public int MsgCount { get; set; }
        public bool HasOrder { get; set; }
        public string MessageCssColor { get; set; }
        public bool Urgent { get; set; }
        public bool IsFaxNotification { get; set; }
        public int MsgTypeId { get; set; }
        public string Typecode { get; set; }
        public string Icon { get; set; }
        public string StatusName { get; set; }
    }

    public class PatientMessagesHistoryGeneralOrder
    {
        public int MsgId { get; set; }
        public int OrderOrINRId { get; set; }
        public string Medication { get; set; }
        public string Qty { get; set; }
        public string Refills { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public string Style { get; set; }
        public int IsHistory { get; set; }
        public string TypeName { get; set; }
        public string TypeCode { get; set; }
        public string IconImageName { get; set; }
    }
}
