﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TopShelfCustomer.Views;
using TopShelfCustomer.Services;

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
        /// SetCurrentPage:
        ///
        /// Pushes the page argument onto the Application Navigation Stack
        /// </summary>
        public static void SetCurrentPage<T>() where T : Page {
            foreach( Page page in Services.PageContainer.Views ) {      //Check if Page of type T already exists
                if( page is T ) {
                    Current.MainPage = page;
                    return;
                }
            }

            /* Page didn't exist */
            var newPage = ( T )Activator.CreateInstance( typeof( T ) ); 
            Services.PageContainer.Views.Add( newPage );       //Add passed Page to the PageContainer static class
            Navigation.PushAsync( newPage );        //Push page onto Navigation stack
            Current.MainPage = newPage;     //Set the current page
        }

        /// <summary>
        /// GoToLastPage:
        ///
        /// Navigates back one page. Acts as a "Back" command
        /// </summary>
        public static void GoToLastPage() {
            Current.MainPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 1];
        }
    }
}