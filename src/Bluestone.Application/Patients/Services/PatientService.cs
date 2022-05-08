using AutoMapper;
using Bluestone.CrossCuttingConcerns.OS;
using Bluestone.Domain.Entities.Patients.RequestModels;
using Bluestone.Domain.Entities.Patients.ViewModels;
using Bluestone.Domain.Identity;
using Bluestone.Domain.Repositories.Patients;
using Bluestone.Domain.Services.Patients;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Application.Patients.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUser _currentUser;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IPatientRepository _patientRepository;

        public PatientService(
            IMapper mapper,
            ILogger<PatientService> logger,
            ICurrentUser currentUser,
            IDateTimeProvider dateTimeProvider,
            IPatientRepository patientRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _currentUser = currentUser;
            _dateTimeProvider = dateTimeProvider;
            _patientRepository = patientRepository;
        }

        public async Task<List<GetPatientListViewModel>> GetPatientListAsync(GetPatientListRequestModel request)
        {
            List<GetPatientListViewModel> patients = (List<GetPatientListViewModel>)await _patientRepository.GetPatientListAsync(request);

            return patients;
        }


        public async Task<List<GetUserPatientListByNameViewModel>> GetUserPatientListByNameAsync(GetUserPatientListByNameRequestModel request)
        {
            List<GetUserPatientListByNameViewModel> patients = (List<GetUserPatientListByNameViewModel>)await _patientRepository.GetUserPatientListByNameAsync(request);

            return patients;
        }

    }
}
