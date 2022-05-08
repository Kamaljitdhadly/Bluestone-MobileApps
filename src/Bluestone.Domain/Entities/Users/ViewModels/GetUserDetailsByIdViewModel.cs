using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Users.ViewModels
{
    public class GetUserDetailsByIdViewModel
    {
        public int UserId { get; set; }
        public int? UserType { get; set; }
        public string Smsnotification { get; set; }
        public string Pin { get; set; }
        public string Notes { get; set; }
        public bool? AllowLogin { get; set; }
        public string EmailValid { get; set; }
        public string Faxnotification { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Emailnotification { get; set; }
        public int? InActive { get; set; }
        public string Cell { get; set; }
        public bool? PasswordResetNextLogin { get; set; }
        public bool IsFacilityAdmin { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string TwoFactorPhoneNumber { get; set; }
        public bool TwoFactorPhoneNumberVerified { get; set; }
        public bool TwoFactorForceAuthentication { get; set; }
        public bool IsCreatedByAdmin { get; set; }
        public bool IsTermConditionChecked { get; set; }

    }
}
