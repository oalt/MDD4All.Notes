/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.Notes.DataModels;
using System.Collections.Generic;

namespace MDD4All.Notes.DataProvider.Contracts
{
    public interface INoteDataProvider
    {
        List<Note> GetAllNotes();

        Note GetNoteByID(string noteGUID);

        void SaveNote(Note note);

        void DeleteNote(string noteGUID);
    }
}
