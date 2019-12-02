using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopShelfCustomer.Api.Models {

    /// <summary>
    /// Store:
    /// 
    /// Model class for a grocery store.
    /// Held in the database with properties
    /// to identify the name, location, and list of
    /// products.
    /// </summary>
    public class Store {
        /// <summary>
        /// Id: the unique identifier for this Store.
        /// </summary>
        public int Id { get; set; } = 0;
        /// <summary>
        /// Name: the name of this Store.
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// Address: the physical address of this Store.
        /// </summary>
        public string Address { get; set; } = "";
        /// <summary>
        /// ImageURL: the web URL for this Store's logo image.
        /// </summary>
        public string ImageURL { get; set; } = "";
    }
}