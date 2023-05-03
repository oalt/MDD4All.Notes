/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.Notes.Apps.NoteEditorWPF;
using MDD4All.Notes.ViewModels;
using System.Windows.Controls;


// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace MDD4All.Notes.Apps.NoteEditor.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            DataContext = App.Current.Services.GetService(typeof(MainViewModel));
        }

    }
}
