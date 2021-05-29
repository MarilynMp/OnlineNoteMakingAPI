using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using OnlineNoteMakingApp.DataAccess;
using OnlineNoteMakingApp.Model;
using OnlineNoteMakingApp.Model.View;
using OnlineNoteMakingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get all users registered
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<UserDetails> GetUser()
        {
            return _userService.GetAllUser();
        }

        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId:int}")]
        public UserDetails GetUserById(int userId)
        {
            return _userService.GetUserById(userId);
        }

        /// <summary>
        /// Get User by name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("{userName}")]
        public UserDetails GetUserByName(string userName)
        {
            return _userService.GetUserByName(userName);
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddUser(UserDetails user)
        {
            return _userService.AddUser(user);
        }

        /// <summary>
        /// Get Users Associated to a note
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("Note/{noteId}")]
        public List<UsersForNotes> GetUsersAssociatedToNote(int noteId)
        {
            return _userService.GetUsersAssociatedToNote(noteId);
        }

        /// <summary>
        /// Get All User Role Types
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("RoleType")]
        public List<UserRoleType> GetAllUserRoleTypes()
        {
            return _userService.GetAllUserRoleTypes();
        }
    }
}
