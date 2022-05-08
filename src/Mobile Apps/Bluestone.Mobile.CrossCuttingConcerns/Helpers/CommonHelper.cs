using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Bluestone.Mobile.CrossCuttingConcerns.Helpers
{
    public class CommonHelper
    {
        public static string FormatDateTime(string sdate, string stime)
        {
            DateTime date = System.Convert.ToDateTime(sdate);

            TimeSpan time = TimeSpan.Parse(stime);

            var dateTime = MergeTime(date, time);
            return dateTime.ToString("dd MMM yyy at HH:mm");
        }

        public static DateTime MergeTime(DateTime date, TimeSpan time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds);
        }

        public static bool IsValidEmail(string email)
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                RegexOptions.None, TimeSpan.FromMilliseconds(200));
            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                try
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();
                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
                catch
                {
                    return match.Value;
                }
            }
            return Regex.IsMatch(email,
                 @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z_])@))" +
                 @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                 RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
    }
}
