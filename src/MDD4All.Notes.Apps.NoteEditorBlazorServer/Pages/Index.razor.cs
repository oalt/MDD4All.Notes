using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using MDD4All.Notes.Apps.NoteEditorBlazorServer;
using MDD4All.Notes.ViewModels;

namespace MDD4All.Notes.Apps.NoteEditorBlazorServer.Pages
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        [Inject]
        public MainViewModel DataContext { get; set; }

        private void OnEditButtonClick()
        {
            if(DataContext.SelectedNote != null)
            {
                DataContext.EditedNote = DataContext.SelectedNote;

                DataContext.EditNoteCommand.Execute(null);
            }
            
        }

        private void OnNewButtonClick()
        {
            DataContext.NewNoteCommand.Execute(null);
        }

        private void OnDeleteButtonClick()
        {
            if (DataContext.SelectedNote != null)
            {
                DataContext.DeleteNoteCommand.Execute(null);
            }
        }

        private void OnEditGoBack()
        {
            StateHasChanged();
        }
    }
}