/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using System.Collections.Generic;
using MDD4All.Notes.DataModels;
using MDD4All.Notes.DataProvider.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MDD4All.Notes.Microservice.Controllers
{
    [Produces("application/json")]
    [Route("notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {

        INoteDataProvider _noteDataProvider;

        public NoteController(INoteDataProvider noteDataProvider)
        {
            _noteDataProvider = noteDataProvider;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Note>), 200)]
        public ActionResult<IEnumerable<Note>> GetAllNotes()
        {
            List<Note> result = new List<Note>();

            result = _noteDataProvider.GetAllNotes();

            return result;
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(Note), 200)]
        [ProducesResponseType(404)]
        public ActionResult<Note> GetNoteByID(string guid)
        {
            ActionResult result = NotFound();

            if(!string.IsNullOrEmpty(guid))
            {
                Note note = _noteDataProvider.GetNoteByID(guid);

                if (note != null)
                {
                    result = new OkObjectResult(note);
                }
            }
            else
            {
                result = BadRequest();
            }

            return result;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Note), 201)]
        public ActionResult CreateNewNote([FromBody] Note note)
        {
            ActionResult result = BadRequest();

            if(note != null)
            {
                _noteDataProvider.SaveNote(note);
                result = Ok();
            }

            return result;
        }

        [HttpPut("{guid}")]
        public ActionResult UpdateNote(string guid, [FromBody] Note note)
        {
            ActionResult result = BadRequest();

            if (note != null && !string.IsNullOrEmpty(note.GUID))
            {
                _noteDataProvider.SaveNote(note);
                result = new OkResult();
            }

            return result;
        }

        [HttpDelete("{guid}")]
        public ActionResult DeleteNote(string guid)
        {
            ActionResult result = BadRequest();

            if(!string.IsNullOrEmpty(guid))
            {
                _noteDataProvider.DeleteNote(guid);
                result = Ok();
            }

            return result;
        }
    }
}
