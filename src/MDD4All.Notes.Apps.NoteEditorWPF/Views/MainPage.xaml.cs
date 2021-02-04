﻿/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using CommonServiceLocator;
using MDD4All.Notes.Apps.NoteEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

            //DataContext = ServiceLocator.Current.GetInstance<MainViewModel>();
        }
    }
}
