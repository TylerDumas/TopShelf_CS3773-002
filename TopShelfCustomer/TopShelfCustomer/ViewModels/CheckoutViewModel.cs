using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// CheckoutViewModel:
    ///
    /// Viewmodel for the CheckoutView menu.
    /// Binds properties to UI values.
    /// </summary>
    public class CheckoutViewModel : BaseViewModel {

        public Cart Cart { get; set; } = new Cart();     //The user's current Cart of items

        private float price;        //The total cost of the order
        public float Price {
            get => price;
            set {
                price = value;
                OnPropertyChanged( "Price" );
            }
        }
        public ObservableCollection<Product> ItemsList { get; set; }    //The visible list of Products
            = new ObservableCollection<Product>();     

        private int numItems;       //The number of items selected
        public int NumItems {
            get => numItems;
            set {
                numItems = value;
                OnPropertyChanged( "NumItems" );
            }
        }

        /* Commands */
        public ICommand PaymentCommand { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CheckoutViewModel() {

            //TODO: Get Cart from previous View

            /* Set the UI Properties */
            Price = Cart.Price;
            NumItems = Cart.Items.Count;

            /* Initialize Commands */
            PaymentCommand = new Command( () => App.SetCurrentPage<PaymentView>() );
        }
    }
}
