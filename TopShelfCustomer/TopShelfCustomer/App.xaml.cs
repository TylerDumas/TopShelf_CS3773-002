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

        public static INavigation Navigation {          //Navigation Manager property
            get;
            private set;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public App() {
            InitializeComponent();

            /* Register Navigation Manager */
            var loginPage = new LoginPage();
            var rootPage = new NavigationPage( loginPage );
            Navigation = rootPage.Navigation;
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
        /// Creates a new Page of type T, removing the old one from the Application state.
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
                    Navigation.PushAsync( freshPage );
                    Current.MainPage = freshPage;
                    break;
                }
            }

            /* Page didn't exist */
            var newPage = ( T )Activator.CreateInstance( typeof( T ) );
            PageContainer.Views.Add( newPage );
            Navigation.PushAsync( newPage );
            Current.MainPage = newPage;
        }

        /// <summary>
        /// SetCurrentPage:
        ///
        /// Pushes the page argument onto the Application Navigation Stack
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
            Navigation.PushAsync( newPage );        //Push page onto Navigation stack
            Current.MainPage = newPage;     //Set the current page
        }

        /// <summary>
        /// ClearPages:
        ///
        /// Clears all Pages from any Application state/dependency containers
        /// </summary>
        public static void ClearPages() {
            PageContainer.Views.Clear();    //Clear Page dependency container
            Navigation.PopToRootAsync();    //Clear Navigation Stack
            Current.MainPage = new LoginPage();     //Change view to blank LoginPage
        }
    }
}
