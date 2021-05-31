using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.Model
{
    public class NoteUserAssociation
    {
        public int UserId { get; set; }

        public int UserRoleId { get; set; }

        public int NoteId { get; set; }
    }
}
