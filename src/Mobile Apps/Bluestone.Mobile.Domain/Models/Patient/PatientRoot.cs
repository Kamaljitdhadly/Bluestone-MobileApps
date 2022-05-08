using System;
using System.Collections.Generic;
using System.Text;

namespace Bluestone.Mobile.Domain.Models.Patient
{
    public class PatientRoot
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<PatientModel> Data { get; set; }
    }
}
