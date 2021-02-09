/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.Notes.Apps.NoteEditor.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace MDD4All.Notes.Apps.NoteEditorWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // App-Initialisierung nicht wiederholen, wenn das Fenster bereits Inhalte enthält.
            // Nur sicherstellen, dass das Fenster aktiv ist.
            if (rootFrame == null)
            {
                // Frame erstellen, der als Navigationskontext fungiert und zum Parameter der ersten Seite navigieren
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;
            }

            
            if (rootFrame.Content == null)
            {
                // Wenn der Navigationsstapel nicht wiederhergestellt wird, zur ersten Seite navigieren
                // und die neue Seite konfigurieren, indem die erforderlichen Informationen als Navigationsparameter
                // übergeben werden

                MainPage mainPage = new MainPage();

                rootFrame.Navigate(mainPage);

                rootFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

                rootFrame.Navigating += OnRootFrameNavigating;

                App.RootFrame = rootFrame;

            }
               
            
        }

        /// <summary>
        /// Event handler for navigation animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnRootFrameNavigating(object sender, NavigatingCancelEventArgs args)
        {
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation();

            thicknessAnimation.Duration = TimeSpan.FromSeconds(0.4);
            thicknessAnimation.DecelerationRatio = 0.7;
            thicknessAnimation.To = new Thickness(0, 0, 0, 0);

            if (args.NavigationMode == NavigationMode.New)
            {
                thicknessAnimation.From = new Thickness(500, 0, 0, 0);
            }
            else if (args.NavigationMode == NavigationMode.Back)
            {
                thicknessAnimation.From = new Thickness(0, 0, 500, 0);
            }
            
            (args.Content as Page).BeginAnimation(MarginProperty, thicknessAnimation);
            
        }

        

        /// <summary>
        /// Wird aufgerufen, wenn die Navigation auf eine bestimmte Seite fehlschlägt
        /// </summary>
        /// <param name="sender">Der Rahmen, bei dem die Navigation fehlgeschlagen ist</param>
        /// <param name="e">Details über den Navigationsfehler</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page ");
        }
    }
}
