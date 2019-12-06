namespace TopShelfCustomer.Models {

    /// <summary>
    /// Store:
    ///
    /// Model class to represent an instance of a grocery store.
    /// Will hold all related information for a grocery store, such as
    /// a product catalog, a name, etc.
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