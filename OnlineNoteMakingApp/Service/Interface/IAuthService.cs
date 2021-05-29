using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.Service.Interface
{
    public interface IAuthService
    {
        bool ValidateUserCreds(string userName, string password);
    }
}
