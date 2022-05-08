using AutoMapper;
using Bluestone.CrossCuttingConcerns.OS;
using Bluestone.Domain.Entities.Facilities.RequestModels;
using Bluestone.Domain.Entities.Facilities.ViewModels;
using Bluestone.Domain.Identity;
using Bluestone.Domain.Repositories.Facilities;
using Bluestone.Domain.Services.Facilities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Application.Facilities.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUser _currentUser;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IFacilityRepository _facilityRepository;

        public FacilityService(
            IMapper mapper,
            ILogger<FacilityService> logger,
            ICurrentUser currentUser,
            IDateTimeProvider dateTimeProvider,
            IFacilityRepository facilityRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _currentUser = currentUser;
            _dateTimeProvider = dateTimeProvider;
            _facilityRepository = facilityRepository;
        }

        public async Task<List<GetFacilityListViewModel>> GetFacilityListAsync(GetFacilityListRequestModel request)
        {
            List<GetFacilityListViewModel> facilities = (List<GetFacilityListViewModel>)await _facilityRepository.GetFacilityListAsync(request);

            return facilities;
        }

        public async Task<GetFacilityDetailsByIdViewModel> GetFacilityDetailsByIdAsync(int facilityId)
        {
            var facility = await _facilityRepository.GetFacilityDetailsByIdAsync(facilityId);

            return facility;
        }

        public async Task<int> UpdateFacilityAsync(UpdateFacilityRequestModel facility)
        {
            return await _facilityRepository.UpdateFacilityAsync(facility);
        }

        public async Task<int> InsertFacilityAsync(InsertFacilityRequestModel facility)
        {
            return await _facilityRepository.InsertFacilityAsync(facility);
        }

        public async Task DeleteFacilityAsync(int facilityId)
        {
            await _facilityRepository.DeleteFacilityAsync(facilityId);
        }
    }
}
