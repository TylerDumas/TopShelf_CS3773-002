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
            userRealName = "Jackson Dumas";     //FIXME: temporary name, replace with user profile
            ReceiptList = new List<OrderReceipt> {
                new OrderReceipt() {
                    OrderDate = "11/25/2019",
                    OrderStoreName = "HEB DeZavala",
                    OrderNumItems = 25,
                    OrderTotalPrice = 100.00f,
                },
                new OrderReceipt() {
                    OrderDate = "11/15/2019",
                    OrderStoreName = "HEB DeZavala",
                    OrderNumItems = 18,
                    OrderTotalPrice = 60.10f,
                },
                new OrderReceipt() {
                    OrderDate = "11/01/2019",
                    OrderStoreName = "HEB 1604 & Blanco",
                    OrderNumItems = 15,
                    OrderTotalPrice = 50.60f,
                }
            };
            /* Initialize Commands */
            NavigateBackCommand = new Command( () => App.SetCurrentPage<HomePage>() );
        }
    }
}
