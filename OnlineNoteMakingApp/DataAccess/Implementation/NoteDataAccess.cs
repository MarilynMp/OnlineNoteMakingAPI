using MySql.Data.MySqlClient;
using OnlineNoteMakingApp.DataAccess.Interface;
using OnlineNoteMakingApp.Model.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.DataAccess.Implementation
{
    public class NoteDataAccess : INoteDataAccess
    {
        private readonly IDataContext _dataContext;
        public NoteDataAccess(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int AddNote(string noteMessage)
        {
            var insertedNoteId = 0;

            using (MySqlConnection conn = _dataContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_AddNote", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("NoteMessage", noteMessage);

                    insertedNoteId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return insertedNoteId;
        }

        public int AddNotesUserAssociation(int noteId, int userId, int userRoleId) 
        {
            var insertedNoteUserAssociationId = 0;

            using (MySqlConnection conn = _dataContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_AddNoteUserAssociation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("NoteId", noteId);
                    cmd.Parameters.AddWithValue("UserId", userId);
                    cmd.Parameters.AddWithValue("UserRoleId", userRoleId);

                    insertedNoteUserAssociationId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return insertedNoteUserAssociationId;
        }

        public bool UpdateNote(string noteMessage, int noteId) 
        {
            var noteUpdated = false;

            using (MySqlConnection conn = _dataContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_UpdateNote", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("NoteMessage", noteMessage);
                    cmd.Parameters.AddWithValue("NoteId", noteId);

                    noteUpdated = Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
            return noteUpdated;
        }

        public bool DeleteNote(int noteId) 
        {
            var noteDeleted = false;

            using (MySqlConnection conn = _dataContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_DeleteNote", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("NoteId", noteId);

                    noteDeleted = Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
            return noteDeleted;
        }

        public List<NotesForUserView> GetNotesForUser(int userId) 
        {
            var notesForUser = new List<NotesForUserView>();

            using (var conn = _dataContext.GetConnection()) 
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_GetNotesForUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("UserId",userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notesForUser.Add(new NotesForUserView()
                            {
                                NoteId = Convert.ToInt32(reader["NoteId"]),
                                NoteMessage = Convert.ToString(reader["NoteMessage"]),
                                UserId = Convert.ToInt32(reader["UserId"]),
                                UserRoleId = Convert.ToInt32(reader["UserRoleId"])
                            });
                        }
                    }
                }
                return notesForUser;
            }
        }

        public bool DeleteNoteAssociation(int noteAssocitaionId)
        {
            var noteAssociationDeleted = false;

            using (MySqlConnection conn = _dataContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_DeleteNoteUserAssociation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("NoteUserAssociationId", noteAssocitaionId);

                    noteAssociationDeleted = Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
            return noteAssociationDeleted;
        }
    }
}
