using Microsoft.Extensions.DependencyInjection;
using OnlineNoteMakingApp.Service.Implementation;
using OnlineNoteMakingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.Register
{
    public static class RegisterService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<INoteService, NoteService>();
        }
    }
}
