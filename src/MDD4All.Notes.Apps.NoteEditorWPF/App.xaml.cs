/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using MDD4All.Notes.Apps.NoteEditor.Navigation;
using MDD4All.Notes.Apps.NoteEditor.Views;
using System.Windows;
using System.Windows.Controls;

namespace MDD4All.Notes.Apps.NoteEditorWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Frame RootFrame { get; set; }
        
        public App()
        {
            WpfNavigationService navigationService = new WpfNavigationService();

            navigationService.Configure("EditNotePage", new EditNotePage());

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
        }
        

    }
}
