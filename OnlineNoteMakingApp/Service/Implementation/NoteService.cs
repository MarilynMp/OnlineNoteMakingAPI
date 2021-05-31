using OnlineNoteMakingApp.DataAccess.Interface;
using OnlineNoteMakingApp.Model.View;
using OnlineNoteMakingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.Service.Implementation
{
    public class NoteService : INoteService
    {
        private readonly INoteDataAccess _noteDataAccess;
        public NoteService(INoteDataAccess noteDataAccess)
        {
            _noteDataAccess = noteDataAccess;
        }

        public int AddNote(string noteMessage)
        {
            return _noteDataAccess.AddNote(noteMessage);
        }

        public bool AddNoteForUser(string noteMessage, int userId, int userRoleId)
        {
            var newNoteId = AddNote(noteMessage);
            var noteUserAssociationId = AddNotesUserAssociation(newNoteId, userId , userRoleId); 

            return true;
        }

        public int AddNotesUserAssociation(int noteId, int userId, int userRoleId)
        {
            return _noteDataAccess.AddNotesUserAssociation(noteId, userId, userRoleId);
        }

        public bool UpdateNote(string noteMessage, int noteId)
        {
            return _noteDataAccess.UpdateNote(noteMessage, noteId);
        }

        public bool DeleteNote(int noteId) 
        {
            return _noteDataAccess.DeleteNote(noteId);
        }

        public List<NotesForUserView> GetNotesForUser(int userId)
        {
            return _noteDataAccess.GetNotesForUser(userId);
        }

        public bool DeleteNoteAssociation(int noteAssocitaionId)
        {
            return _noteDataAccess.DeleteNoteAssociation(noteAssocitaionId);
        }

    }
}
