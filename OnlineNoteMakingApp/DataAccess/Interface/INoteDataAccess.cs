﻿using OnlineNoteMakingApp.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.DataAccess.Interface
{
    public interface INoteDataAccess
    {
        int AddNote(string noteMessage);

        int AddNotesUserAssociation(int noteId, int userId, int userRoleId);

        bool UpdateNote(string noteMessage, int noteId);

        bool DeleteNote(int noteId);

        List<NotesForUserView> GetNotesForUser(int userId);

        bool DeleteNoteAssociation(int noteAssocitaionId);

    }
}
