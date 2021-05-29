using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.Model.View
{
    public class NotesForUserView
    {
        public int NoteId { get; set; }

        public string NoteMessage { get; set; }

        public int UserId { get; set; }

        public int UserRoleId { get; set; }
    }
}
