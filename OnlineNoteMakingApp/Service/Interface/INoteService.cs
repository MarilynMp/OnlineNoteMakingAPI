using OnlineNoteMakingApp.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.Service.Interface
{
    public interface INoteService
    {
        int AddNote(string noteMessage);

        bool AddNoteForUser(string noteMessage, int userId, int userRoleId);

        bool UpdateNote(string noteMessage, int noteId);

        bool DeleteNote(int noteId);

        List<NotesForUserView> GetNotesForUser(int userId);

        bool DeleteNoteAssociation(int noteAssocitaionId);
    }
}
