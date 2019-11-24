using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// ChooseStoreViewModel:
    ///
    /// ViewModel for Choose Store View.
    /// Handles the selection of a default store for the user.
    /// </summary>
    public class ChooseStoreViewModel : BaseViewModel {

        #region Properties

        public ObservableCollection<Store> NearbyStores { get; set; }       //Collection of Stores close to the current User

        /* Commands */
        public ICommand NavigateBackCommand { get; }        //Command to open home page (back button)
        public ICommand SelectStoreCommand { get; }

        #endregion

        #region Class Methods

        public ChooseStoreViewModel() {
            Title = "Choose your Favorite Store";     //Set Title property of this ContentPage

            /* Initialize Collection of Stores */
            NearbyStores = new ObservableCollection<Store> {

                //FIXME: Temporary Stores to test the View
                new Store { StoreName = "HEB DeZavala", StoreAddress = "1111 DeZavala Road" },
                new Store { StoreName = "HEB 1604 and Blanco", StoreAddress = "2222 Blanco Road" },
                new Store { StoreName = "HEB 1604 and Bandera", StoreAddress = "2222 Bandera Road" }
            };       

            /* Initialize Commands */
            NavigateBackCommand = new Command( () => App.SetCurrentPage<HomePage>() );
            SelectStoreCommand = new Command( SelectStoreClicked );
        }

        /// <summary>
        /// SelectStoreClicked:
        ///
        /// Handler for the "Select Store" Button in the SelectStoreView.
        /// FIXME: Include details about how this works
        /// </summary>
        public void SelectStoreClicked() {
            //TODO: Set the selected Store so that the next View can access it.
            Debug.WriteLine( "Selected a new Default Store" );
            App.SetCurrentPage<HomePage>();
        }

        #endregion
    }

}
