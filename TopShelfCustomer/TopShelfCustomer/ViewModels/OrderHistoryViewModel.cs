using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Services;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// OrderHistoryViewModel:
    ///
    /// ViewModel for the OrderHistory View.
    /// Responsible for indirectly exposing the model logic to the view.
    /// </summary>
    public class OrderHistoryViewModel : BaseViewModel {

        #region Properties

            public ObservableCollection<OrderReceipt> ReceiptList { get; set; } = new ObservableCollection<OrderReceipt>();    //The list of receipts to populate the ListView

            public ICommand NavigateBackCommand { get; }        //Command for the "Back" button

        #endregion Properties

        #region Class Methods
            /// <summary>
            /// Constructor
            /// </summary>
            public OrderHistoryViewModel () {

                InitializeReceipts( UserContainer.CurrentUser.EmailAddress );       //Initialize ReceiptsList

                /* Initialize Commands */
                NavigateBackCommand = new Command( () => App.SetNewPage<HomePage>() );
            }

            /// <summary>
            /// InitializeReceipts:
            ///
            /// Populates the receipt list from the API
            /// and the global User instance.
            /// </summary>
            /// <param name="email"> The User's email to search by </param>
            private async void InitializeReceipts( string email ) {
                ApiHelper api = new ApiHelper();
                string sanitizedEmail = email.Replace( ".", "-" );      //Make endpoint url-friendly
                string apiEndpoint = "Order/GetOrdersByEmail/" + sanitizedEmail;
                foreach ( OrderReceipt order in UserContainer.Orders ) {        //Fetch orders from global User
                    ReceiptList.Add( order );
                }
                List<OrderReceipt> orders = await api.GetAsync<List<OrderReceipt>>( apiEndpoint );      //Fetch orders from API
                foreach( OrderReceipt order in orders ) {       //Add orders to bindable collection
                    ReceiptList.Add( order );
                }
            }
        #endregion
    }
}