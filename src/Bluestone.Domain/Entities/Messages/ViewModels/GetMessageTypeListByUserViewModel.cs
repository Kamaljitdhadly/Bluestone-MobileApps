using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Messages.ViewModels
{
    public class GetMessageTypeListByUserViewModel
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeCode { get; set; }
        public string IconImageName { get; set; }
    }
}
