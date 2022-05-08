using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Identity.ViewModels
{
    public class LoginViewModel
    {
        public string Result { get; set; }
        public string Token { get; set; }
        public string Notes { get; set; }
        public string PasswordResetNextLogin { get; set; }
    }
}
