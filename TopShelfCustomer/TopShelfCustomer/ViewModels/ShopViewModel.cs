using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Services;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// ShopViewModel:
    ///
    /// ViewModel for Shop View.
    /// Handles the selection of products from the User's default Store.
    /// </summary>
    public class ShopViewModel : BaseViewModel {

        #region Properties

        public string SelectedStoreName { get; set; } = "";         //The name of the default selected Store
        public ObservableCollection<Product> ShopInventory { get; set; } = new ObservableCollection<Product>();      //Collection of this Store's Item inventory. Bound to View

        /* Commands */
        public ICommand NavigateBackCommand { get; }            //Command for "back" button
        public ICommand CheckoutCommand { get; }        //Command for the "Checkout" Button

        #endregion Properties



        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public ShopViewModel () {
            InitializeStore();      //Initialize the bindable properties

            NavigateBackCommand = new Command( () => App.SetCurrentPage<HomePage>() );      //Initialize "Back Button" Command
            CheckoutCommand = new Command( Checkout );      //Initialize the Checkout Command
        }

        /// <summary>
        /// Checkout:
        ///
        /// Handles all logic to be executed when the "Checkout" button is clicked
        /// </summary>
        private void Checkout () {
            //TODO: Implement Checkout
            Debug.WriteLine( "Pressed the Checkout Button" );
        }

        /// <summary>
        /// InitializeStore:
        ///
        /// Sets all bindable properties for the ShopView.
        /// Also calls the API to fetch the store/product data.
        /// </summary>
        private async Task InitializeStore () {
            ApiHelper api = new ApiHelper();
            var productsList = await api.GetAsync<List<Product>>( "Store/GetAllProducts" );     //FIXME: correct endpoint
            if ( UserContainer.CurrentUser.StoreName == "" ) {       //Check if the User has a default Store
                Debug.WriteLine( "Error: could not find default store" );
                App.SetNewPage<ChooseStoreView>();
            }
            SelectedStoreName = UserContainer.CurrentUser.StoreName;        //Set the Header "Store Name" label
            foreach ( Product product in productsList ) {       //Add all products in the returned list to the bindable list
                ShopInventory.Add( product );
            }
        }

        #endregion Class Methods
    }
}