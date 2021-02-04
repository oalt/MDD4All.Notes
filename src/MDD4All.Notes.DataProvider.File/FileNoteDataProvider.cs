/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.Notes.DataModels;
using MDD4All.Notes.DataProvider.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MDD4All.Notes.DataProvider.File
{
    public class FileNoteDataProvider : INoteDataProvider
    {
        private string _fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\notes.json";

        private DataModels.Notes _notes = new DataModels.Notes();

        public FileNoteDataProvider()
        {
            InitializeData();
        }


        private void InitializeData()
        {

            if(System.IO.File.Exists(_fileName))
            {
                string json = System.IO.File.ReadAllText(_fileName);

                _notes = JsonConvert.DeserializeObject<DataModels.Notes>(json);
            }

        }

        private void SaveDataToFile()
        {
            string json = JsonConvert.SerializeObject(_notes);

            System.IO.File.WriteAllText(_fileName, json);
        }

        public List<Note> GetAllNotes()
        {
            return _notes.NoteElements;
        }

        public Note GetNoteByID(string noteGUID)
        {
            Note result = null;

            if (_notes.NoteElements.Count > 0)
            {
                result = _notes.NoteElements.Find(note => note.GUID == noteGUID);
            }

            return result;
        }

        public void SaveNote(Note note)
        {
            Note existingNote = GetNoteByID(note.GUID);

            if(existingNote != null)
            {
                int index = _notes.NoteElements.FindIndex(n => n.GUID == note.GUID);

                _notes.NoteElements[index] = note;
            }
            else
            {
                _notes.NoteElements.Add(note);
            }

            SaveDataToFile();
        }

        public void DeleteNote(string noteGUID)
        {
            Note existingNote = GetNoteByID(noteGUID);

            if (existingNote != null)
            {
                _notes.NoteElements.Remove(existingNote);
                SaveDataToFile();
            }
            
        }
    }
}
