using Bluestone.Infrastructure.Notification.Sms.Azure;
using Bluestone.Infrastructure.Notification.Sms.Twilio;

namespace Bluestone.Infrastructure.Notification.Sms
{
    public class SmsOptions
    {
        public string Provider { get; set; }

        public TwilioOptions Twilio { get; set; }

        public AzureOptions Azure { get; set; }

        public bool UsedFake()
        {
            return Provider == "Fake";
        }

        public bool UsedTwilio()
        {
            return Provider == "Twilio";
        }

        public bool UsedAzure()
        {
            return Provider == "Azure";
        }
    }
}
