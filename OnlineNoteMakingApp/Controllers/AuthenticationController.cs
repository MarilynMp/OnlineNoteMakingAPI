using Microsoft.AspNetCore.Mvc;
using OnlineNoteMakingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("{userName}/{password}")]
        public bool ValidateUserCreds(string userName, string password)
        {
            return _authService.ValidateUserCreds(userName, password);
        }
    }
}
