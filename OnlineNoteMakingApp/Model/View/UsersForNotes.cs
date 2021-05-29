using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.Model.View
{
    public class UsersForNotes
    {
        public int NoteUserAssociationId { get; set; }

        public int NoteId { get; set; }

        public string UserName { get; set; }

        public int UserId { get; set; }

        public int UserRoleId { get; set; }

        public string UserRoleName { get; set; }
    }
}
