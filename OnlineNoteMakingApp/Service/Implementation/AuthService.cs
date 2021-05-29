using OnlineNoteMakingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.Service.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        public AuthService(IUserService userService)
        {
            _userService = userService;
        }

        public bool ValidateUserCreds(string userName, string password)
        {
            return _userService.CheckIfUserExistsForCreds(userName, password);
        }

    }
}
