using System;
using System.Collections.Generic;
using System.Text;

namespace Bluestone.Mobile.Domain.Models.Patient
{
    public class DeletePatientCommand
    {
        public int PatientId { get; }

        public DeletePatientCommand(int patientId)
        {
            PatientId = patientId;
        }
    }
}
