using System;
using System.Collections.Generic;

namespace TopShelfCustomer.Models {

    /// <summary>
    /// OrderReceipt:
    ///
    /// Represents a previous order/transaction.
    /// Holds all information about a specific purchase and delivery.
    /// </summary>
    public class OrderReceipt {

        #region Properties

        public string OrderName { get; set; }       //The real name of the User that made the purchase
        public string OrderStoreName { get; set; }       //The store that the User purchased from
        public float OrderTotalPrice { get; set; }       //The overall total of the purchase
        public float OrderSubTotalPrice { get; set; }        //The total of the purchase before tax
        public int OrderNumItems { get; set; }     //The total number of items purchased
        public string OrderDate { get; set; }
        public List<Item> PurchasedItems { get; set; }      //The list of all Items purchased

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public OrderReceipt() {

        }

        #endregion
    }
}
