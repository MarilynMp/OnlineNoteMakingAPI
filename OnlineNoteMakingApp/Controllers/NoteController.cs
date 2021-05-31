using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineNoteMakingApp.Model.View;
using OnlineNoteMakingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        /// <summary>
        /// Add a Note Message
        /// </summary>
        /// <param name="noteMessage"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddNote([FromBody]string noteMessage)
        {
            return _noteService.AddNote(noteMessage);
        }

        /// <summary>
        /// Add a note associated to a particular user with a role
        /// </summary>
        /// <param name="noteMessage"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("{userId}/{userRoleId}")]
        public bool AddNoteForUser([FromBody]string noteMessage, int userId, int userRoleId)
        {
            return _noteService.AddNoteForUser(noteMessage, userId, userRoleId);
        }

        /// <summary>
        /// Update a note message by note id 
        /// </summary>
        /// <param name="noteMessage"></param>
        /// <param name="noteId"></param>
        /// <returns></returns>
        [HttpPut("{noteId}")]
        public bool UpdateNote([FromBody]string noteMessage, int noteId)
        {
            return _noteService.UpdateNote(noteMessage, noteId);
        }

        /// <summary>
        /// Delete a note by note id
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        [HttpDelete("{noteId}")]
        public bool DeleteNote(int noteId)
        {
            return _noteService.DeleteNote(noteId);
        }

        /// <summary>
        /// Get Notes Associated with a user
        /// </summary>
        /// <param name="noteMessage"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public List<NotesForUserView> GetNotesForUser(int userId)
        {
            return _noteService.GetNotesForUser(userId);
        }

        /// <summary>
        /// Delete association between a user and a note
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        [HttpDelete("NoteAssociation/{noteAssocitaionId}")]
        public bool DeleteNoteAssociation(int noteAssocitaionId)
        {
            return _noteService.DeleteNoteAssociation(noteAssocitaionId);
        }

        /// <summary>
        /// Add association between an existing note and user with a role
        /// </summary>
        /// <param name="noteId"></param>
        /// <param name="userId"></param>
        /// <param name="userRoleId"></param>
        /// <returns></returns>
        [HttpPost("NoteUserAssociation/{noteId}/{userId}/{userRoleId}")]
        public int AddNotesUserAssociation(int noteId, int userId, int userRoleId)
        {
            return _noteService.AddNotesUserAssociation(noteId, userId, userRoleId);
        }

    }
}
