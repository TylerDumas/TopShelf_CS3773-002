using System;
using System.Collections.Generic;

namespace TopShelfCustomer.Models {

    /// <summary>
    /// Store:
    ///
    /// Model class to represent an instance of a grocery store.
    /// Will hold all related information for a grocery store, such as
    /// a product catalog, a name, etc.
    /// </summary>
    public class Store {

        public string StoreName { get; set; }       //The name of the store
        public string StoreAddress { get; set; }        //The address of the store
        public List<Item> StoreCatalog { get; set; }        //This store's list of Items

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="storeName"> the name of the Store </param>
        /// <param name="storeAddress"> the address of the Store </param>
        public Store( string storeName, string storeAddress ) {
            this.StoreName = storeName;
            this.StoreAddress = storeAddress;
            this.StoreCatalog = new List<Item>();
        }
    }
}
