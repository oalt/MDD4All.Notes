/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MDD4All.Notes.DataModels;
using MDD4All.Notes.DataProvider.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MDD4All.Notes.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private INoteDataProvider _noteDataProvider;
        private INavigationService _navigationService;

        public MainViewModel(INoteDataProvider noteDataProvider,
                             INavigationService navigationService)
        {
            _noteDataProvider = noteDataProvider;
            _navigationService = navigationService;

            NewNoteCommand = new RelayCommand(ExecuteNewNoteCommand);
            EditNoteCommand = new RelayCommand(ExecuteEditNoteCommand);
            DeleteNoteCommand = new RelayCommand(ExecuteDeleteNoteCommand, CanExecuteDeleteNoteCommand);
            SaveNoteCommand = new RelayCommand(ExecuteSaveNoteCommand);
            GoBackCommand = new RelayCommand(ExecuteGoBackCommand);

            
            InitializeData();
        }

        private void InitializeData()
        {
            if(_noteDataProvider != null)
            {
                List<Note> notesData = _noteDataProvider.GetAllNotes();

                foreach(Note noteData in notesData)
                {
                    NoteViewModel noteViewModel = new NoteViewModel(noteData);
                    Notes.Add(noteViewModel);
                }
            }
        }

        private NoteViewModel _noteSelectedNote;

        public NoteViewModel SelectedNote
        {
            get { return _noteSelectedNote; }
            set
            {
                _noteSelectedNote = value;
                RaisePropertyChanged("SelectedNote");
            }
        }


        private NoteViewModel _editedNote;

        public NoteViewModel EditedNote
        {
            get { return _editedNote; }
            set
            {
                _editedNote = value;
                RaisePropertyChanged("EditedNote");
            }
        }


        public ObservableCollection<NoteViewModel> Notes { get; set; } = new ObservableCollection<NoteViewModel>();

        #region COMMAND_DEFINITIONS

        public ICommand NewNoteCommand { get; private set; }

        public ICommand EditNoteCommand { get; private set; }

        public ICommand DeleteNoteCommand { get; private set; }

        public ICommand SaveNoteCommand { get; private set; }

        public ICommand GoBackCommand { get; private set; }

        #endregion

        #region COMMAND_IMPLEMENTATIONS
        private void ExecuteNewNoteCommand()
        {
            if(_noteDataProvider != null)
            {
                Note newNote = new Note();

                EditedNote = new NoteViewModel(newNote);

                _navigationService.NavigateTo("EditNotePage", this);
            }
        }

        private void ExecuteEditNoteCommand()
        {
            if(SelectedNote != null)
            {
                EditedNote = SelectedNote;

                _navigationService.NavigateTo("EditNotePage", this);
            }
        }


        private void ExecuteDeleteNoteCommand()
        {
            if(SelectedNote != null)
            {
                if(_noteDataProvider != null)
                {
                    _noteDataProvider.DeleteNote(SelectedNote.Note.GUID);
                    Notes.Remove(SelectedNote);
                }
            }
        }

        private bool CanExecuteDeleteNoteCommand()
        {
            return true;
        }

        private void ExecuteGoBackCommand()
        {
            _navigationService.GoBack();
        }

        private void ExecuteSaveNoteCommand()
        {
            if(_noteDataProvider != null)
            {
                _noteDataProvider.SaveNote(EditedNote.Note);

                if(!Notes.Contains(EditedNote))
                {
                    Notes.Add(EditedNote);
                }
            }
        }
        #endregion

    }
}
