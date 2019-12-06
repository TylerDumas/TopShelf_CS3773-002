using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Services;
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

        public ObservableCollection<Store> NearbyStores { get; set; }       //Collection of Stores close to the current User

        private Store selectedStore;         //The currently selected Store in the ListView

        public Store SelectedStore {
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

        #endregion Properties

        #region Class Methods

        public ChooseStoreViewModel () {
            Title = "Choose your Favorite Store";     //Set Title property of this ContentPage
            InitializeNearbyStores();

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
        public void SelectStoreClicked () {
            //TODO: Set the selected Store so that the next View can access it.
            Debug.WriteLine( "Selected a new Default Store" );
            App.SetCurrentPage<HomePage>();
        }

        /// <summary>
        /// InitializeNearbyStores:
        ///
        /// Fetches the stores from the API and sets the
        /// bindable properties for the ChooseStoreView.
        /// </summary>
        public async Task InitializeNearbyStores () {
            ApiHelper apiHelper = new ApiHelper();
            NearbyStores = new ObservableCollection<Store>();
            var stores = await apiHelper.GetAsync<Store>( "Store/GetStoreById/1" );       //Get Stores from API FIXME: add GetByStoreName or something to api

            //foreach( Store store in stores ) {
            //    NearbyStores.Add( store );
            //    if( store.Name == UserContainer.CurrentUser.StoreName ) {       //Check if this is the User's preffered Store
            //        SelectedStore = store;
            //    }
            //}

            NearbyStores.Add( stores );
            if ( SelectedStore == null ) {       //Check if no store was found to be preferred
                SelectedStore = NearbyStores[0];
            }
        }

        #endregion Class Methods
    }
}