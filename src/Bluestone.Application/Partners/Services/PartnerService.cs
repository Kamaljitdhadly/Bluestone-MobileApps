using AutoMapper;
using Bluestone.CrossCuttingConcerns.OS;
using Bluestone.Domain.Entities.Partners.RequestModels;
using Bluestone.Domain.Entities.Partners.ViewModels;
using Bluestone.Domain.Identity;
using Bluestone.Domain.Repositories.Partners;
using Bluestone.Domain.Services.Partners;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Application.Partners.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUser _currentUser;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IPartnerRepository _partnerRepository;

        public PartnerService(
            IMapper mapper,
            ILogger<PartnerService> logger,
            ICurrentUser currentUser,
            IDateTimeProvider dateTimeProvider,
            IPartnerRepository partnerRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _currentUser = currentUser;
            _dateTimeProvider = dateTimeProvider;
            _partnerRepository = partnerRepository;
        }


        public async Task<List<GetPartnerListViewModel>> GetPartnerListAsync(GetPartnerListRequestModel request)
        {
            List<GetPartnerListViewModel> partners = (List<GetPartnerListViewModel>)await _partnerRepository.GetPartnerListAsync(request);

            return partners;
        }

    }
}
