using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace TopShelfCustomer.Models {

    /// <summary>
    /// Item:
    ///
    /// Model class to represent a grocery item.
    /// Holds all information regarding a single grocery item.
    /// </summary>
    public class Item {

        #region Properties

        public string ItemName { get; set; }        //The Item's Human-readable name
        public int ItemId { get; set; }         //The Item's product ID
        public float Price { get; set; }        //The Item's price
        public string ItemQuantityInput { get; set; }        //The Item's quantity/num selected as a string (to bind to Entry control) FIXME: This is a temporary hack to make this work
        public int ItemQuantity { get; set; }       //The Item's quantity as an int.

        public ICommand AddItem { get; }        //Command for the "Add" button on each Item

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Item() {

            /* Command Initialization */
            AddItem = new Command( AddQuantity );
        }

        /// <summary>
        /// AddQuantity:
        ///
        /// Takes the user input for this Item's quantity and
        /// converts it to an Int.
        /// </summary>
        private void AddQuantity() {
            int temp = Convert.ToInt32( ItemQuantityInput );
            if( temp != ItemQuantity ) {
                ItemQuantity = temp;
                Debug.WriteLine( $"You selected {ItemQuantity} of {ItemName}" );
            }
        }       

        #endregion
    }
}
