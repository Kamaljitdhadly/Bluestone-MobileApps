using Bluestone.Infrastructure.Notification.Email;
using Bluestone.Infrastructure.Notification.Sms;
using Bluestone.Infrastructure.Notification.Web;

namespace Bluestone.Infrastructure.Notification
{
    public class NotificationOptions
    {
        public EmailOptions Email { get; set; }

        public SmsOptions Sms { get; set; }

        public WebOptions Web { get; set; }
    }
}
