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

        public string OrderName { get; private set; }       //The real name of the User that made the purchase
        public Store OrderStore { get; private set; }       //The store that the User purchased from
        public float OrderTotal { get; private set; }       //The overall total of the purchase
        public float OrderSubTotal { get; private set; }        //The total of the purchase before tax
        public int PurchasedItemCount { get; private set; }     //The total number of items purchased
        public List<Item> PurchasedItems { get; private set; }      //The list of all Items purchased

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderName"> the real name of the User that ordered </param>
        /// <param name="orderStore">  the Store that the order was placed from </param>
        /// <param name="orderTotal"> the total price of the order </param>
        /// <param name="orderSubTotal"> the price of the order before tax </param>
        /// <param name="purchasedItemCount"> the total number of items purchased </param>
        /// <param name="purchasedItems"> the list of items that were purchased </param>
        public OrderReceipt( string orderName, Store orderStore, float orderTotal, float orderSubTotal, int purchasedItemCount, List<Item> purchasedItems ) {
            OrderName = orderName;
            OrderStore = orderStore;
            OrderTotal = orderTotal;
            OrderSubTotal = orderSubTotal;
            PurchasedItemCount = purchasedItemCount;
            PurchasedItems = purchasedItems;
        }

        #endregion
    }
}
