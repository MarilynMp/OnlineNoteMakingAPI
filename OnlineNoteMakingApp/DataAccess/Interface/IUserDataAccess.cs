using OnlineNoteMakingApp.Model;
using OnlineNoteMakingApp.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.DataAccess.Interface
{
    public interface IUserDataAccess
    {
        List<UserDetails> GetAllUser();

        UserDetails GetUserById(int userId);

        UserDetails GetUserByName(string userName);

        bool AddUser(UserDetails user);

        bool CheckIfUserExistsForCreds(string userName, string password);

        List<UsersForNotes> GetUsersAssociatedToNote(int noteId);

        List<UserRoleType> GetAllUserRoleTypes();
    }
}
