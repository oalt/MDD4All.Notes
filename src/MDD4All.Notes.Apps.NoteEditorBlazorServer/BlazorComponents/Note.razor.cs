using Microsoft.AspNetCore.Components;
using MDD4All.Notes.ViewModels;

namespace MDD4All.Notes.Apps.NoteEditorBlazorServer.BlazorComponents
{
    public partial class Note
    {
        [Parameter]
        public NoteViewModel DataContext { get; set; }

        private string NoteStyle
        {
            get
            {
                string result = "card noteStyle";
                if (DataContext.IsSelected)
                {
                    result += " selected";
                }
                
                return result;
            }
        }
    }
}