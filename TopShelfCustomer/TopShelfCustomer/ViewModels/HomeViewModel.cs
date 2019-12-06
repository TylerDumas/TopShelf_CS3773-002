using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Services;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// HomeViewModel:
    ///
    /// ViewModel for the Home page
    /// Allows the interface to connect to the model classes directly
    /// </summary>
    public class HomeViewModel : BaseViewModel {

        #region Properties

        public ObservableCollection<Coupon> CouponsList { get; set; } = new ObservableCollection<Coupon>();     //The list of coupons to populate the view

        public string UserRealName { get; }        //The current User's real name
        private string userStoreName;       //String representation of this User's default Store

        public string UserStoreName {
            get => userStoreName;
            set {
                userStoreName = value;
                OnPropertyChanged( "UserStoreName" );
            }
        }

        /* Commands */
        public ICommand OpenSettingsCommand { get; }       //Command to open Settings Menu
        public ICommand OpenCreateOrderCommand { get; }        //Command to open Order Creation Menu
        public ICommand OpenOrderHistoryCommand { get; }        //Command to open the Order History Menu
        public ICommand ChangeStoreCommand { get; }     //Command to open "Change Default Store" Menu

        #endregion Properties

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeViewModel () {
            Title = "Home";
            UserRealName = UserContainer.CurrentUser.FullName;      //Get User's name from the global User
            UserStoreName = UserContainer.CurrentUser.StoreName;        //Get User's store name from the global User

            InitializeCoupons();        //Populate Coupon ListView

            /* Initialize Commands */
            OpenSettingsCommand = new Command( () => App.SetCurrentPage<SettingsPage>() );
            OpenCreateOrderCommand = new Command( () => App.SetCurrentPage<ShopView>() );
            OpenOrderHistoryCommand = new Command( () => App.SetCurrentPage<OrderHistoryView>() );
            ChangeStoreCommand = new Command( () => App.SetCurrentPage<ChooseStoreView>() );
        }

        /// <summary>
        /// InitializeCoupons:
        ///
        /// Correctly populates the view with coupons from the
        /// global User's zip code.
        /// </summary>
        private async Task InitializeCoupons () {
            ApiHelper api = new ApiHelper();

            int zipCode = UserContainer.CurrentUser.ZipCode;        //Get the User's Zip Code
            string couponPath = "Coupon/GetCouponsByZipCode/" + zipCode;    //Get the path to the coupon endpoint

            var coupons = await api.GetAsync<List<Coupon>>( couponPath );      //Fetch the list of coupons
            foreach ( Coupon coupon in coupons ) {       //Add all elements of the Coupon list to the observable collection
                CouponsList.Add( coupon );
            }
        }

        #endregion Class Methods
    }
}