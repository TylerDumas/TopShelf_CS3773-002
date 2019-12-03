namespace TopShelfCustomer.Models {

    /// <summary>
    /// Item:
    ///
    /// Model class to represent a grocery item.
    /// Holds all information regarding a single grocery item.
    /// </summary>
    public class Product {

        /// <summary>
        /// Id: The unique identifier for this product.
        /// </summary>
        public int Id { get; set; } = 0;
        /// <summary>
        /// Name: The name of this product.
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// Price: The cost of this product.
        /// </summary>
        public float Price { get; set; } = 0.0f;
    }
}
