using System;
using System.Windows.Input;
using System.Diagnostics;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;
using Xamarin.Forms;
using System.ComponentModel;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// CreateOrderViewModel
    ///
    /// ViewModel for the CreateOrder View.
    /// Allows the settings to communicate with the model classes.
    /// </summary>
    public class CreateOrderViewModel : BaseViewModel {

        public ICommand OpenHomePageCommand { get; }        //Command to open home page (back button)

        public CreateOrderViewModel() {
            Title = "Create Order";

            OpenHomePageCommand = new Command( LaunchHomePage );
        }

        /// <summary>
        /// LaunchHomePage:
        ///
        /// Changes the Applications current page to the Home page
        /// </summary>
        void LaunchHomePage() {
            Application.Current.MainPage = new HomePage();
        }
    }
}
