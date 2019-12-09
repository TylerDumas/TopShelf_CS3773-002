using System;
using System.Collections.Generic;

namespace TopShelfCustomer.Models {

    /// <summary>
    /// Cart:
    ///
    /// Model class to represent a shopping cart.
    /// All items selected when shopping are added to an instance
    /// of this class. 
    /// </summary>
    public class Cart {

        public List<Product> Items { get; set; } = new List<Product>();     //The current List of Products selected
        public float Price { get; set; } = 0.0f;        //The total cost of this Cart

    }
}
