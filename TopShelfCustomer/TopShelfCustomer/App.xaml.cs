using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TopShelfCustomer.Views;

namespace TopShelfCustomer {

    /// <summary>
    /// App:
    ///
    /// The root class of the application.
    /// Holds functions that are triggered on changes in the App's state
    /// </summary>
    public partial class App : Application {

        public App() {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage( new LoginPage() );
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
    }
}
