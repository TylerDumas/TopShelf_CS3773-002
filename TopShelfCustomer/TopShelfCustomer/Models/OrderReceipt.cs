using System;

namespace TopShelfCustomer.Models {

    /// <summary>
    /// OrderReceipt:
    ///
    /// Represents a previous order/transaction.
    /// Holds all information about a specific purchase and delivery.
    /// </summary>
    public class OrderReceipt {

        /// <summary>
        /// Id: the unique identifier for this Order (used in SQL database).
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// OrderNumber: the number to identify this Order.
        /// </summary>
        public int OrderNumber { get; set; } = 0;

        /// <summary>
        /// StoreName: the name of the Store that this Order took place.
        /// </summary>
        public string StoreName { get; set; } = "";

        /// <summary>
        /// NumItems: the number of items purchased for this Order.
        /// </summary>
        public int NumItems { get; set; } = 0;

        /// <summary>
        /// LastFour: the last four digits of this Order's payment method.
        /// </summary>
        public int LastFour { get; set; } = 0;

        /// <summary>
        /// Price: The total cost of this Order.
        /// </summary>
        public float Price { get; set; } = 0.0f;

        /// <summary>
        /// EmailAddress: The email address associated with this Order's account.
        /// </summary>
        public string EmailAddress { get; set; } = "";

        /// <summary>
        /// Date: the Date and Time for this Order.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// DriverName: The name of the delivery driver for this Order.
        /// </summary>
        public string DriverName { get; set; } = "";
    }
}