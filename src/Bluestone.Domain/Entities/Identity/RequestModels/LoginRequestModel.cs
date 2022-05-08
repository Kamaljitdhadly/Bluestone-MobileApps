using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Identity.RequestModels
{
    public class LoginRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
