using Microsoft.Extensions.DependencyInjection;
using OnlineNoteMakingApp.DataAccess.Implementation;
using OnlineNoteMakingApp.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.Register
{
    public static class RegisterDataAccess
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUserDataAccess, UserDataAccess>();
            services.AddScoped<INoteDataAccess, NoteDataAccess>();
        }

    }
}
