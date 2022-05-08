using Bluestone.Mobile.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Domain.Services.User
{
    public interface IUserService
    {
        Task<ObservableCollection<PatientCareTeamModel>> GetPatientCareTeamAsync(string token);
    }
}
