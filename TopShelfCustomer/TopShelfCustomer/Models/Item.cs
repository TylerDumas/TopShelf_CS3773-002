using System;
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
        public Image ItemImage { get; set; }        //The Item's product image

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="itemName"> The name of the Item </param>
        /// <param name="itemId"> The ID of the Item </param>
        /// <param name="price"> The price of the Item </param>
        public Item( string itemName, int itemId, float price ) {
            this.ItemName = itemName;
            this.ItemId = itemId;
            this.Price = price;
        }
    }
}
