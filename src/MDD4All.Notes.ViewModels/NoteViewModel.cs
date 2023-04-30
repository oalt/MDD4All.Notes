/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using GalaSoft.MvvmLight;
using MDD4All.Notes.DataModels;

namespace MDD4All.Notes.ViewModels
{
    public class NoteViewModel : ViewModelBase
    {
        
        public NoteViewModel(Note note)
        {
            Note = note;
        }

        public Note Note { get; set; }

        public string Title
        {
            get 
            {
                string result = "";

                if (Note != null)
                {
                    result = Note.Title;
                }
                
                return result; 
            }

            set
            {
                if(Note != null)
                {
                    Note.Title = value;
                }
                RaisePropertyChanged("Title");
            }
        }

 

        public string Description
        {
            get
            {
                string result = "";

                if (Note != null)
                {
                    result = Note.Description;
                }

                return result;
            }

            set
            {
                if (Note != null)
                {
                    Note.Description = value;
                }
                RaisePropertyChanged("Description");
            }
        }

        public string GUID
        {
            get 
            {
                string result = "";

                if (Note != null)
                {
                    result = Note.GUID;
                }

                return result;
            }
        }

    }
}
