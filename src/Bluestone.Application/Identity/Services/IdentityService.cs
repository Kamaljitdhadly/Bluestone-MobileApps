using AutoMapper;
using Bluestone.CrossCuttingConcerns.Helpers;
using Bluestone.CrossCuttingConcerns.OS;
using Bluestone.Domain.Entities.Identity.RequestModels;
using Bluestone.Domain.Identity;
using Bluestone.Domain.Repositories.Identity;
using Bluestone.Domain.Repositories.Users;
using Bluestone.Domain.Services.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bluestone.Application.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUser _currentUser;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IIdentityRepository _identityRepository;
        private readonly IUserRepository _userRepository;

        public IdentityService(
            IMapper mapper,
            ILogger<IdentityService> logger,
            ICurrentUser currentUser,
            IDateTimeProvider dateTimeProvider,
            IIdentityRepository identityRepository,
            IUserRepository userRepository)
        {
            _logger = logger;
            _currentUser = currentUser;
            _dateTimeProvider = dateTimeProvider;
            _mapper = mapper;
            _identityRepository = identityRepository;
            _userRepository = userRepository;
        }


        public bool ValidateUserPassword(string userPassword, string enteredPassword)
        {
            string hashedPassword = MD5CryptographyHelper.EncryptToMD5(enteredPassword);
            return userPassword.Equals(hashedPassword);
        }

        public async Task<List<Claim>> GetUserRolesAsync(GetUserRolesRequestModel request)
        {
            List<Claim> claims = new();
            List<string> roles = (List<string>)await _identityRepository.GetUserRolesAsync(request);
            
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

    }
}
