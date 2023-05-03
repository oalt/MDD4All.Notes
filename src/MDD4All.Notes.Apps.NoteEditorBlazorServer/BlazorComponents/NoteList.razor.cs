using Microsoft.AspNetCore.Components;
using MDD4All.Notes.ViewModels;

namespace MDD4All.Notes.Apps.NoteEditorBlazorServer.BlazorComponents
{
    public partial class NoteList
    {
        [Parameter]
        public MainViewModel DataContext { get; set; }

        private void OnNoteClicked(string noteGUID)
        {
            foreach(NoteViewModel noteViewModel in DataContext.Notes)
            {
                if(noteViewModel.GUID== noteGUID)
                {
                    DataContext.SelectedNote = noteViewModel;
                    StateHasChanged();
                    break;
                }
            }
        }
    }
}