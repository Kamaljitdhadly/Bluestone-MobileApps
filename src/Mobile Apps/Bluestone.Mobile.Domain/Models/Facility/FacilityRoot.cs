using System;
using System.Collections.Generic;
using System.Text;

namespace Bluestone.Mobile.Domain.Models.Facility
{
    public class FacilityRoot
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<FacilityModel> Data { get; set; }
    }
}
