using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Partners.ViewModels
{
    public class GetPartnerListViewModel
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string BillingCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
