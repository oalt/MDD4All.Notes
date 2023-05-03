using GalaSoft.MvvmLight.Views;

namespace MDD4All.Notes.Apps.NoteEditorBlazorServer.Naviagation
{
    public class BlazorNavigationService : INavigationService
    {
        public BlazorNavigationService() { }

        public string CurrentPageKey { get; set; } = "";

        public void GoBack()
        {
            ;
        }

        public void NavigateTo(string pageKey)
        {
            ;
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            ;
        }
    }
}
