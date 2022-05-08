using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Identity.ViewModels
{
    public class ValidateJwtTokenViewModel
    {
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string UserName { get; set; }
        public List<Claim> Claims { get; set; }
    }
}
