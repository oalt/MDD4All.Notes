using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using MDD4All.Notes.Apps.NoteEditorBlazorServer.Naviagation;
using MDD4All.Notes.DataProvider.Contracts;
using MDD4All.Notes.DataProvider.File;
using MDD4All.Notes.ViewModels;

namespace MDD4All.Notes.Apps.NoteEditorBlazorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            BlazorNavigationService navigationService = new BlazorNavigationService();

            builder.Services.AddSingleton<INavigationService>(navigationService);

            builder.Services.AddSingleton<INoteDataProvider, FileNoteDataProvider>();

            builder.Services.AddScoped<MainViewModel>();

            WebApplication app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();

        }
    }
}

