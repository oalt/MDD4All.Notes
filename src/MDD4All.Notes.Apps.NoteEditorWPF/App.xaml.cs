/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using MDD4All.Notes.Apps.NoteEditor.Navigation;
using MDD4All.Notes.Apps.NoteEditor.Views;
using MDD4All.Notes.DataProvider.Contracts;
using MDD4All.Notes.DataProvider.File;
using MDD4All.Notes.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
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
            Services = ConfigureServices();

            IHostBuilder builder = Host.CreateDefaultBuilder();

            builder.ConfigureServices((hostContext, services) =>
            {
                WpfNavigationService navigationService = new WpfNavigationService();

                navigationService.Configure("EditNotePage", new EditNotePage());

                services.AddSingleton<INavigationService>(navigationService);

                services.AddSingleton<INoteDataProvider, FileNoteDataProvider>();

                services.AddScoped<MainViewModel>();
            });

            IHost host = builder.Build();

            Services = host.Services;

            //SimpleIoc.Default.Register<INavigationService>(() => navigationService);
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            ServiceCollection services = new ServiceCollection();

            

            return services.BuildServiceProvider();
        }
    }
}
