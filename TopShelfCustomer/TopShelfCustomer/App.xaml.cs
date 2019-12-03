using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TopShelfCustomer.Views;
using TopShelfCustomer.Services;
using System.Diagnostics;

namespace TopShelfCustomer {

    /// <summary>
    /// App:
    ///
    /// The root class of the application.
    /// Holds functions that are triggered on changes in the App's state
    /// </summary>
    public partial class App : Application {

        /// <summary>
        /// Constructor
        /// </summary>
        public App() {
            InitializeComponent();

            /* Register Navigation Manager */
            var rootPage = new LoginPage();
            MainPage = rootPage;
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }

        /// <summary>
        /// GetCurrentPage:
        ///
        /// Returns the Current Main Page of the application
        /// </summary>
        /// <returns> the currently presented View </returns>
        public static Page GetCurrentPage() {
            return Current.MainPage;
        }

        /// <summary>
        /// SetNewPage:
        ///
        /// Attempts to find the page (of type T) in the application's state.
        /// If a page is found, it removes it from the application's state
        /// and creates a new instance of it. Then it navigates to the newly
        /// created page.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void SetNewPage<T>() where T : Page {
            foreach( Page page in PageContainer.Views ) {
                if( page is T ) {
                    if( PageContainer.Views.Contains( page ) ) {
                        PageContainer.Views.Remove( page );
                    }
                    var freshPage = ( T )Activator.CreateInstance( typeof( T ) );
                    PageContainer.Views.Add( freshPage );
                    Current.MainPage = freshPage;
                    break;
                }
            }

            /* Page didn't exist */
            var newPage = ( T )Activator.CreateInstance( typeof( T ) );
            PageContainer.Views.Add( newPage );
            Current.MainPage = newPage;
        }

        /// <summary>
        /// SetCurrentPage:
        ///
        /// Attempts to find a page of type T in the application's state.
        /// If no page is found, it creates a new one and navigates to it.
        /// </summary>
        public static void SetCurrentPage<T>() where T : Page {
            foreach( Page page in PageContainer.Views ) {      //Check if Page of type T already exists
                if( page is T ) {
                    Current.MainPage = page;
                    return;
                }
            }

            /* Page didn't exist */
            var newPage = ( T )Activator.CreateInstance( typeof( T ) );
            PageContainer.Views.Add( newPage );       //Add passed Page to the PageContainer static class
            Current.MainPage = newPage;     //Set the current page
        }

        /// <summary>
        /// ClearPages:
        ///
        /// Clears all Application state/dependency containers
        /// </summary>
        public static void ClearAppData() {
            PageContainer.Views.Clear();    //Clear Page dependency container
            Current.MainPage = new LoginPage();     //Change view to blank LoginPage
            UserContainer.CurrentUser = new Models.User();      //Clear the global User instance
            SettingsContainer.ClearSettings();      //Clear User Settings
        }
    }
}
