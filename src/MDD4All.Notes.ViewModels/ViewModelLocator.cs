/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MDD4All.Notes.DataProvider.Contracts;
using MDD4All.Notes.DataProvider.File;
using MDD4All.Notes.DataProvider.Mockup;

namespace MDD4All.Notes.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<INoteDataProvider, MockupNoteDataProvider>();
            }
            else
            {
                SimpleIoc.Default.Register<INoteDataProvider, FileNoteDataProvider>();
            }

            SimpleIoc.Default.Register<MainViewModel>();

            
        }


        public MainViewModel Main
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainViewModel>();
            }
        }
    }
}
