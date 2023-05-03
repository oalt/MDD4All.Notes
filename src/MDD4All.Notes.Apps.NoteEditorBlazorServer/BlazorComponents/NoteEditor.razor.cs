using Microsoft.AspNetCore.Components;
using MDD4All.Notes.ViewModels;

namespace MDD4All.Notes.Apps.NoteEditorBlazorServer.BlazorComponents
{
    public partial class NoteEditor
    {
        [Parameter]
        public MainViewModel DataContext { get; set; }

        [Parameter]
        public EventCallback GoBackEventCallback { get; set; }

        private void OnBackButtonClick()
        {
            DataContext.EditedNote = null;
            GoBackEventCallback.InvokeAsync();
        }

        private void OnSaveButtonClick()
        {
            DataContext.SaveNoteCommand.Execute(null);
        }
    }
}