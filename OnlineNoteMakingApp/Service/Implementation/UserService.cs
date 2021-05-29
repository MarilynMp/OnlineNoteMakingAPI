using OnlineNoteMakingApp.DataAccess.Interface;
using OnlineNoteMakingApp.Model;
using OnlineNoteMakingApp.Model.View;
using OnlineNoteMakingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserDataAccess _userDataAccess;
        public UserService(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public List<UserDetails> GetAllUser() 
        {
            return _userDataAccess.GetAllUser();
        }

        public UserDetails GetUserById(int userId) 
        {
            return _userDataAccess.GetUserById(userId);
        }

        public UserDetails GetUserByName(string userName)
        {
            return _userDataAccess.GetUserByName(userName);
        }

        public bool AddUser(UserDetails user)
        {
            var isExistingUserName = GetUserByName(user.UserName)!=null ? true : false;
            if (isExistingUserName)
                throw new Exception("User Name Already Exists");

            return _userDataAccess.AddUser(user);

        }

        public bool CheckIfUserExistsForCreds(string userName,string password)
        {
            return _userDataAccess.CheckIfUserExistsForCreds(userName, password);
        }

        public List<UsersForNotes> GetUsersAssociatedToNote(int noteId) 
        {
            return _userDataAccess.GetUsersAssociatedToNote(noteId);
        }

        public List<UserRoleType> GetAllUserRoleTypes()
        {
            return _userDataAccess.GetAllUserRoleTypes();
        }
    }
}
