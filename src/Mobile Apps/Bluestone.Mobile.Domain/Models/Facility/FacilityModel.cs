using System;
using System.Collections.Generic;
using System.Text;

namespace Bluestone.Mobile.Domain.Models.Facility
{
    public class FacilityModel
    {
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

    }
}
