/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.Notes.DataModels;
using MDD4All.Notes.DataProvider.Contracts;
using System.Collections.Generic;

namespace MDD4All.Notes.DataProvider.Mockup
{
    public class MockupNoteDataProvider : INoteDataProvider
    {

        private List<Note> _notes = new List<Note>
        {
            new Note()
            {
                GUID = "1",
                Title = "Note 1",
                Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua."
            },
            new Note()
            {
                GUID = "2",
                Title = "Note 2",
                Description = "At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet."
            },
            new Note()
            {
                GUID = "3",
                Title = "Note 3",
                Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua."
            },
        };

        public void DeleteNote(string noteGUID)
        {
            ;
        }

        public List<Note> GetAllNotes()
        {
            return _notes;
        }

        public Note GetNoteByID(string noteGUID)
        {
            Note result = null;

            if (_notes.Count > 0)
            {
                result = _notes.Find(note => note.GUID == noteGUID);
            }

            return result;
        }

        public void SaveNote(Note note)
        {
            ;
        }
    }
}
