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

        public string Name { get; set; }       //The real name of the User that made the purchase
        public string StoreName { get; set; }       //The store that the User purchased from
        public float Price { get; set; }       //The overall total of the purchase
        public float SubTotalPrice { get; set; }        //The total of the purchase before tax
        public int NumItems { get; set; }     //The total number of items purchased
        public string Date { get; set; }
        public List<Product> PurchasedItems { get; set; }      //The list of all Items purchased

        #endregion Properties
    }
}