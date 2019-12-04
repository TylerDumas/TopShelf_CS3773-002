using System.Windows.Input;
using Xamarin.Forms;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;
using System.Collections.ObjectModel;

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

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public OrderHistoryViewModel() {
            /* Initialize Commands */
            NavigateBackCommand = new Command( () => App.SetCurrentPage<HomePage>() );
        }
    }
}
