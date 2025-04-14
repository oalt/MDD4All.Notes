/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using MDD4All.MVVM;
using MDD4All.Notes.DataProvider.Contracts;
using MDD4All.Notes.DataProvider.File;
using MDD4All.Notes.DataProvider.Mockup;
using Microsoft.Extensions.DependencyInjection;

namespace MDD4All.Notes.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            if (DesignerLibrary.IsInDesignModeStatic)
            {
                serviceCollection.AddSingleton<INoteDataProvider, MockupNoteDataProvider>();
                
            }
            else
            {
                serviceCollection.AddSingleton<INoteDataProvider, FileNoteDataProvider>();
            }

            serviceCollection.AddSingleton<MainViewModel>();

            Ioc.Default.ConfigureServices(serviceCollection.BuildServiceProvider());
                   
        }


        public MainViewModel Main
        {
            get
            {
                return Ioc.Default.GetService<MainViewModel>();
            }
        }
    }
}
