using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// CreateOrderViewModel
    ///
    /// ViewModel for the CreateOrder View.
    /// Allows the settings to communicate with the model classes.
    /// </summary>
    public class CreateOrderViewModel : BaseViewModel {

        #region Properties

        public ObservableCollection<Store> NearbyStores { get; set; }       //Collection of Stores close to the current User

        /* Commands */
        public ICommand NavigateBackCommand { get; }        //Command to open home page (back button)
        public ICommand ContinueWithStoreCommand { get; }

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateOrderViewModel() {
            Title = "Create New Order";     //Set Title property of this ContentPage

            NearbyStores = new ObservableCollection<Store>();       //Initialize Collection of Stores

            //FIXME: Temporary Stores to test the View
            NearbyStores.Add( new Store{ StoreName = "HEB DeZavala", StoreAddress = "1111 DeZavala Road" } );
            NearbyStores.Add( new Store { StoreName = "HEB 1604 and Blanco", StoreAddress = "2222 Blanco Road" } );
            NearbyStores.Add( new Store { StoreName = "HEB 1604 and Bandera", StoreAddress = "2222 Bandera Road" } );

            /* Initialize Commands */
            NavigateBackCommand = new Command( () => App.SetCurrentPage<HomePage>() );
            ContinueWithStoreCommand = new Command( SelectStoreClicked );
        }

        /// <summary>
        /// SelectStoreClicked:
        ///
        /// Handler for the "Select Store" Button in the CreateOrderView.
        /// FIXME: Include details about how this works
        /// </summary>
        public void SelectStoreClicked() {
            //TODO: Set the selected Store so that the next View can access it.
        }

        #endregion
    }
}
