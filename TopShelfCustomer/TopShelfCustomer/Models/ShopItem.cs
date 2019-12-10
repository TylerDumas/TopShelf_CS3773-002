using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TopShelfCustomer.Models {

    /// <summary>
    /// ShopItem:
    ///
    /// Abstraction of a product used to
    /// display a product in the ShopView with
    /// correct formatting.
    /// </summary>
    public sealed class ShopItem : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;       //Event fired on changes to bindable properties

        public Product Item { get; set; } = new Product();      //This ShopItem's encapsulated product

        private int quantity;       //This ShopItem's selected quantity
        public int Quantity {
            get => quantity;
            set {
                quantity = value;
                OnPropertyChanged( "Quantity" );
            }
        }

        private float price;        //This ShopItem's total price (multiplied by quantity)
        public float Price {
            get => price;
            set {
                price = value;
                OnPropertyChanged( "Price" );
            }
        }

        /// <summary>
        /// OnPropertyChanged:
        ///
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        void OnPropertyChanged( [CallerMemberName] string propertyName = "" ) {
            var changed = PropertyChanged;
            if ( changed == null )
                return;

            changed.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}
