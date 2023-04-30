using GalaSoft.MvvmLight.Views;
using MDD4All.Notes.Apps.NoteEditorWPF;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MDD4All.Notes.Apps.NoteEditor.Navigation
{
    public class WpfNavigationService : INavigationService
    {
        private readonly Dictionary<string, Page> _pagesByKey = new Dictionary<string, Page>();

        public object Parameter { get; set; }

        public string CurrentPageKey { get; set; }

        public void Configure(string key, Page page)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(key))
                {
                    _pagesByKey[key] = page;
                }
                else
                {
                    _pagesByKey.Add(key, page);
                }
            }
        }

        public void GoBack()
        {
            Frame rootFrame = App.RootFrame;

            if (rootFrame != null)
            {
                rootFrame.GoBack();
            }
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public virtual void NavigateTo(string pageKey, object parameter)
        {
            lock (_pagesByKey)
            {
                if (!_pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
                }

                Frame rootFrame = App.RootFrame;
                if (rootFrame != null)
                {
                    Page page = _pagesByKey[pageKey];
                    if (page != null)
                    {
                        page.DataContext = parameter;
                        rootFrame.Navigate(page);
                    }
                    
                }
                
            }
        }

    }
}
