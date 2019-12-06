namespace TopShelfCustomer.Api.Models {

    /// <summary>
    /// Coupon:
    ///
    /// Model class for a coupon/advertisement.
    /// </summary>
    public sealed class Coupon {

        /// <summary>
        /// Id: The unique identifier for this Coupon.
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Name: The title/headline for this Coupon.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// StoreName: The name of this Coupon's offerer/store franchise.
        /// </summary>
        public string StoreName { get; set; } = "";

        /// <summary>
        /// Description: The description/explanation of this Coupon.
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// StoreZipCode: The area-identifier for this Coupon.
        /// </summary>
        public int StoreZipCode { get; set; } = 0;

        /// <summary>
        /// ImageURL: The URL to this Coupon's advertisement image.
        /// </summary>
        public string ImageURL { get; set; } = "";
    }
}