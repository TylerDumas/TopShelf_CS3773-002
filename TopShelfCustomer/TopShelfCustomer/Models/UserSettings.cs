namespace TopShelfCustomer.Models {

    /// <summary>
    /// UserSettings:
    ///
    /// Contains all settings for a given user.
    /// Implemented in <see cref="TopShelfCustomer.Services.SettingsContainer"/>
    /// to act as a global reference for a given user's settings.
    /// </summary>
    public sealed class UserSettings {

        #region Properties

        public bool SaveReceiptsSetting { get; set; }       //Save Receipts to device setting
        public bool AllowExternalLinks { get; set; }        //Prompt for external links setting
        public bool CouponPushNotifications { get; set; }       //Get push notifications for coupons
        public bool CouponEmailNotifications { get; set; }      //Get email notifications for coupons
        public bool OrderPushNotifications { get; set; }        //Get push notifications for order status
        public bool OrderEmailNotifications { get; set; }       //Get email notifications for order status

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>This constructor initializes the default values for a new user </remarks>
        public UserSettings () {
            SaveReceiptsSetting = false;
            AllowExternalLinks = false;
        }

        /// <summary>
        /// SettingTypes:
        ///
        /// Enum to hold the names of each settings.
        /// Used to avoid spelling errors when referencing a property
        /// on this object.
        /// </summary>
        public enum SettingTypes {
            SaveReceiptsSetting,
            AllowExternalLinks,
            CouponPushNotifications,
            CouponEmailNotifications,
            OrderPushNotifications,
            OrderEmailNotifications
        }

        #endregion Properties
    }
}