using System;
using System.Collections.Generic;
using System.Text;

namespace Bluestone.Mobile.Domain.Models.User
{
    public class PatientCareTeamModel
    {
        public PatientCareTeamModel(int userId, string name, string email, string color)
        {
            this.UserId = userId;
            this.Name = name;
            this.Email = email;
            this.Color = color;
        }

        public int UserId { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Color { get; set; }
    }
}
