using AutoMapper;
using Bluestone.CrossCuttingConcerns.OS;
using Bluestone.Domain.Entities.Users.ViewModels;
using Bluestone.Domain.Identity;
using Bluestone.Domain.Repositories.Users;
using Bluestone.Domain.Services.Users;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Bluestone.Application.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUser _currentUser;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserRepository _userRepository;

        public UserService(
            IMapper mapper,
            ILogger<UserService> logger,
            ICurrentUser currentUser,
            IDateTimeProvider dateTimeProvider,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _currentUser = currentUser;
            _dateTimeProvider = dateTimeProvider;
            _userRepository = userRepository;
        }

        public async Task<GetUserDetailsByUserIdViewModel> GetUserDetailsByUserIdAsync(int userId)
        {
            return await _userRepository.GetUserDetailsByUserIdAsync(userId);
        }

        public async Task<GetUserDetailsByUsernameViewModel> GetUserDetailsByUsernameAsync(string username)
        {
            return await _userRepository.GetUserDetailsByUsernameAsync(username);
        }

    }
}
