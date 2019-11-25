using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class ChooseStoreViewModel : BaseViewModel, INotifyPropertyChanged {

        #region Properties

        public ObservableCollection<StoreDisplay> NearbyStores { get; set; }       //Collection of Stores close to the current User

        private StoreDisplay selectedStore;         //The currently selected Store in the ListView
        public StoreDisplay SelectedStore {
            get {
                return selectedStore;
            }
            set {
                selectedStore = value;
                OnPropertyChanged( "SelectedStore" );
            }
        }

        /* Commands */
        public ICommand NavigateBackCommand { get; }        //Command to open home page (back button)
        public ICommand SelectStoreCommand { get; }         //Command to confirm store selection

        #endregion

        #region Class Methods

        public ChooseStoreViewModel() {
            Title = "Choose your Favorite Store";     //Set Title property of this ContentPage

            /* Initialize Collection of Stores */
            NearbyStores = new ObservableCollection<StoreDisplay> {

                //FIXME: Temporary Stores to test the View
                new StoreDisplay { Name = "HEB DeZavala", Address = "1111 DeZavala Road" },
                new StoreDisplay { Name = "HEB 1604 and Blanco", Address = "2222 Blanco Road" },
                new StoreDisplay { Name = "HEB Bandera and 1604", Address = "3333 Bandera Road" }
            };
            SelectedStore = NearbyStores[0];
            

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
