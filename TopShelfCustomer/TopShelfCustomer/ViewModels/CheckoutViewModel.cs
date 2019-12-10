using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Services;
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

        private float price;        //The total cost of the order
        public float Price {
            get => price;
            set {
                price = value;
                OnPropertyChanged( "Price" );
            }
        }
        public ObservableCollection<ShopItem> ItemsList { get; set; }    //The visible list of Products
            = new ObservableCollection<ShopItem>();     

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
        public ICommand NavigateBackCommand { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CheckoutViewModel() {
            /* Set the UI Properties */            
            foreach( ShopItem product in UserContainer.UserCart.Items ) {       //Add cart items to bindable list
                if( product.Quantity > 0 && !ItemsList.Contains( product ) ) {
                    ItemsList.Add( product );
                }
            }
            Price = UserContainer.UserCart.Price;       //Get total Cart cost
            NumItems = ItemsList.Count;     //Get total Cart # different Products

            /* Initialize Commands */
            PaymentCommand = new Command( () => App.SetCurrentPage<PaymentView>() );
            NavigateBackCommand = new Command( () => App.SetCurrentPage<ShopView>() );
        }
    }
}
