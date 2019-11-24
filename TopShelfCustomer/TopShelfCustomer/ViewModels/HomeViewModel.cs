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

        public string UserRealName { get; private set; }        //The current User's real name
        private string userStoreName;       //String representation of this User's default Store
        public string UserStoreName {
            get {
                return userStoreName;
            }
            set {
                userStoreName = value;
                OnPropertyChanged( "UserStoreName" );
            }
        }
        public Store UserStore { get; set; }        //The current User's favorite Store

        /* Commands */
        public ICommand OpenSettingsCommand { get; }       //Command to open Settings Menu
        public ICommand OpenCreateOrderCommand { get; }        //Command to open Order Creation Menu
        public ICommand ChangeStoreCommand { get; }     //Command to open "Change Default Store" Menu

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeViewModel() {
            Title = "Home";

            /* FIXME: Temporary User to test name display */
            User temp = new User() {
                Name = "Jackson Dumas",
                UserStore = new Store { StoreName="HEB DeZavala", StoreAddress="111 DeZavala Road" },
                Email = "tylerdumas3@hotmail.com",
            };
            UserRealName = "Jackson Dumas";
            UserStore = temp.UserStore;
            UserStoreName = UserStore.StoreName;

            /* Initialize Commands */
            OpenSettingsCommand = new Command( () => App.SetCurrentPage<SettingsPage>() );
            OpenCreateOrderCommand = new Command( () => App.SetCurrentPage<ShopView>() );
            ChangeStoreCommand = new Command( () => App.SetCurrentPage<ChooseStoreView>() );
        }

        #endregion
    }
}
