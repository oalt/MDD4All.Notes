/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using CommunityToolkit.Mvvm.ComponentModel;
using MDD4All.Notes.DataModels;

namespace MDD4All.Notes.ViewModels
{
    public class NoteViewModel : ObservableObject
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
                OnPropertyChanged("Title");
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
                OnPropertyChanged("Description");
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

        private bool _isSelected = false;

        public bool IsSelected
        {
            get 
            { 
                return _isSelected; 
            }

            set 
            { 
                _isSelected = value; 
            }
        }


    }
}
