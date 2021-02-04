﻿/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MDD4All.Notes.DataProvider.Contracts;
using MDD4All.Notes.DataProvider.File;
using MDD4All.Notes.DataProvider.Mockup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MDD4All.Notes.Apps.NoteEditor.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<INoteDataProvider, MockupNoteDataProvider>();
            }
            else
            {
                SimpleIoc.Default.Register<INoteDataProvider, FileNoteDataProvider>();
            }
            SimpleIoc.Default.Register<MainViewModel>();

            SimpleIoc.Default.Register<Frame>();
        }


        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
    }
}
