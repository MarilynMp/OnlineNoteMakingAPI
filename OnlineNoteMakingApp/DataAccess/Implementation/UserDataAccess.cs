using MySql.Data.MySqlClient;
using OnlineNoteMakingApp.DataAccess.Interface;
using OnlineNoteMakingApp.Model;
using OnlineNoteMakingApp.Model.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.DataAccess.Implementation
{
    
    public class UserDataAccess : IUserDataAccess
    {
        private readonly IDataContext _dataContext;
        public UserDataAccess(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        

        public List<UserDetails> GetAllUser()
        {
            var list = new List<UserDetails>();

            using (MySqlConnection conn = _dataContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_GetAllUserDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new UserDetails()
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                UserName = reader["UserName"].ToString(),
                                Password = reader["Password"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public UserDetails GetUserById(int userId) 
        {
            UserDetails userDetails = null;

            using (MySqlConnection conn = _dataContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_GetUserDetailsById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("UserIdentifier", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userDetails = new UserDetails()
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                UserName = reader["UserName"].ToString(),
                                Password = reader["Password"].ToString()
                            };
                        }
                    }
                }
            }
            return userDetails;
        }

        public UserDetails GetUserByName(string userName)
        {
            UserDetails userDetails = null;

            using (MySqlConnection conn = _dataContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_GetUserDetailsByName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("UserName", userName);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userDetails = new UserDetails()
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                UserName = reader["UserName"].ToString(),
                                Password = reader["Password"].ToString()
                            };
                        }
                    }
                }
            }
            return userDetails;
        }

        public bool AddUser(UserDetails user) 
        {
            using (MySqlConnection conn = _dataContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_AddUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("UserName", user.UserName);
                    cmd.Parameters.AddWithValue("UserPassword", user.Password);

                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        public bool CheckIfUserExistsForCreds(string userName, string password)
        {
            var isUserCredsValis = false;

            using (MySqlConnection conn = _dataContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_CheckIfUserExistsForCreds", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("UserName", userName);
                    cmd.Parameters.AddWithValue("UserPassword", password);

                    isUserCredsValis = Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
            return isUserCredsValis;
        }

        public List<UsersForNotes> GetUsersAssociatedToNote(int noteId)
        {
            var users = new List<UsersForNotes>();

            using (MySqlConnection conn = _dataContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_GetUsersForNote", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("NoteId", noteId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new UsersForNotes()
                            {
                                NoteId = Convert.ToInt32(reader["NoteId"]),
                                NoteUserAssociationId = Convert.ToInt32(reader["NoteUserAssnId"]),
                                UserId = Convert.ToInt32(reader["UserId"]),
                                UserName = reader["UserName"].ToString(),
                                UserRoleId = Convert.ToInt32(reader["UserRoleTypeId"]),
                                UserRoleName = reader["RoleTypeName"].ToString()
                            });
                        }
                    }
                }
            }
            return users;
        }

        public List<UserRoleType> GetAllUserRoleTypes()
        {
            var userRoles = new List<UserRoleType>();

            using (MySqlConnection conn = _dataContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_GetUserRoles", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userRoles.Add(new UserRoleType()
                            {
                                UserRoleTypeId = Convert.ToInt32(reader["UserRoleTypeId"]),
                                UserRoleTypeName = reader["RoleTypeName"].ToString()
                            });
                        }
                    }
                }
            }
            return userRoles;
        }

    }

    
}
