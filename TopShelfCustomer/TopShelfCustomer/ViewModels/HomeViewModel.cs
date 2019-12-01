using System.ComponentModel;
using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// HomeViewModel:
    ///
    /// ViewModel for the Home page
    /// Allows the interface to connect to the model classes directly
    /// </summary>
    public class HomeViewModel : BaseViewModel, INotifyPropertyChanged {

        #region Properties

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

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeViewModel() {
            Title = "Home";

            /* Initialize Commands */
            OpenSettingsCommand = new Command( () => App.SetCurrentPage<SettingsPage>() );
            OpenCreateOrderCommand = new Command( () => App.SetCurrentPage<ShopView>() );
            OpenOrderHistoryCommand = new Command( () => App.SetCurrentPage<OrderHistoryView>() );
            ChangeStoreCommand = new Command( () => App.SetCurrentPage<ChooseStoreView>() );
        }

        #endregion
    }
}
