using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// StoreViewModel:
    ///
    /// ViewModel for Store View.
    /// Handles the selection of products from the User's default Store.
    /// </summary>
    public class StoreViewModel : BaseViewModel {

        #region Properties

        public UriImageSource StoreImage { get; set; }       //The Store's Image(HEB Logo, etc.) FIXME: This is temporary, remove this and its View element if you want

        public Store SelectedStore { get; set; }            //The default Store selected by the User
        public ObservableCollection<Item> StoreInventory { get; set; }       //Collection of this Store's Item inventory. Bound to View

        /* Commands */
        public ICommand NavigateBackCommand { get; }            //Command for "back" button
        public ICommand CheckoutCommand { get; }        //Command for the "Checkout" Button

        #endregion      

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public StoreViewModel() {

            StoreImage = new UriImageSource { Uri = new System.Uri( "https://pbs.twimg.com/profile_images/1131606709313712129/H5XKewbN.png" ) };        //FIXME: Remove this if you want

            /* Temporary Store and Inventory Instantiation */
            SelectedStore = new Store { StoreName = "HEB DeZavala", StoreAddress = "1111 DeZavala Road" };      //Temporary Store instantiation
            StoreInventory = new ObservableCollection<Item> {
                new Item{ ItemName = "Cereal", Price = 6.99f, ItemId = 1 },
                new Item{ ItemName = "Bread", Price = 1.00f, ItemId = 2 },
                new Item{ ItemName = "Precious Gems", Price = 10.00f, ItemId = 3 },
                new Item{ ItemName = "Gypsy Tears", Price = 0.99f, ItemId = 4 },
                new Item{ ItemName = "Armadillo Meat", Price = 7.67f, ItemId = 5 }
            };

            NavigateBackCommand = new Command( () => App.SetCurrentPage<HomePage>() );      //Initialize "Back Button" Command
            CheckoutCommand = new Command( Checkout );      //Initialize the Checkout Command
        }

        /// <summary>
        /// Checkout:
        ///
        /// Handles all logic to be executed when the "Checkout" button is clicked
        /// </summary>
        private void Checkout() {
            //TODO: Implement Checkout
            Debug.WriteLine( "Pressed the Checkout Button" );
        }

        #endregion
    }
}
