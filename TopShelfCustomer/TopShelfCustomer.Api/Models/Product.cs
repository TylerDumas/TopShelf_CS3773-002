namespace TopShelfCustomer.Api.Models {

    /// <summary>
    /// Product:
    ///
    /// Model class for an item that can
    /// be purchased from a store. This class
    /// will be stored in the database.
    /// </summary>
    public sealed class Product {

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