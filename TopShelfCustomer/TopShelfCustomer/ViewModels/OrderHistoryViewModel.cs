using System.Windows.Input;
using Xamarin.Forms;
using TopShelfCustomer.Views;
using TopShelfCustomer.Services;
using System.ComponentModel;
using TopShelfCustomer.Models;
using System.Collections.Generic;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// OrderHistoryViewModel:
    ///
    /// ViewModel for the OrderHistory View.
    /// Responsible for indirectly exposing the model logic to the view.
    /// </summary>
    public class OrderHistoryViewModel : BaseViewModel {

        #region Properties

        private string userRealName;        //The user's full name
        public string UserRealName {
            get => userRealName;
            set {
                userRealName = value;
                OnPropertyChanged( "UserRealName" );
            }
        }
        public List<OrderReceipt> ReceiptList { get; set; }     //The list of receipts to populate the ListView

        public ICommand NavigateBackCommand { get; }        //Command for the "Back" button

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public OrderHistoryViewModel() {
            userRealName = UserContainer.CurrentUser.FullName;     //FIXME: temporary name, replace with user profile

            /* Initialize Commands */
            NavigateBackCommand = new Command( () => App.SetCurrentPage<HomePage>() );
        }
    }
}
