using System;
using System.Collections.Generic;
using System.Text;

namespace Bluestone.Domain.Models.Patient
{
    public class CreatePatientCommand
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public CreatePatientCommand(int patientId, string firstName, string lastName, string phone, string email)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }
    }
}
