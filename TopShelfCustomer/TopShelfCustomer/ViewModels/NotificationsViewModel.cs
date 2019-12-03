using System;
using System.Windows.Input;
using System.Diagnostics;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;
using Xamarin.Forms;
using System.ComponentModel;
using System.Reflection;
using TopShelfCustomer.Services;
using Newtonsoft.Json.Linq;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// NotificationsViewModel:
    ///
    /// Allows the Notifications Settings View to communicate with the model classes.
    /// Also allows binding between XAML properties and code.
    /// </summary>
    public class NotificationsViewModel : BaseViewModel {

        #region Properties

        JObject jsonObject = new JObject();     //Reusable JSON object

        private string userRealName;            //String to define the User's real name. (Bound to Text fields)
        public string UserRealName {
            get {
                return userRealName;
            }
            set {
                userRealName = value;
                OnPropertyChanged( "UserRealName" );
            }
        }
        private bool isCouponPushSwitchToggled;     //Bool to define whether the "Coupon Push Notifications" setting is toggled
        public bool IsCouponPushSwitchToggled {
            get => isCouponEmailSwitchToggled;
            set {
                isCouponPushSwitchToggled = value;
                ToggleSwitchSetting( UserSettings.SettingTypes.CouponPushNotifications.ToString(), isCouponPushSwitchToggled );
                OnPropertyChanged( "IsCouponPushSwitchToggled" );
            }
        }
        private bool isCouponEmailSwitchToggled;     //Bool to define whether the "Coupon Email Notifications" setting is toggled
        public bool IsCouponEmailSwitchToggled {
            get => isCouponEmailSwitchToggled;
            set {
                isCouponEmailSwitchToggled = value;
                ToggleSwitchSetting( UserSettings.SettingTypes.CouponEmailNotifications.ToString(), isCouponEmailSwitchToggled );
                OnPropertyChanged( "IsCouponEmailSwitchToggled" );
            }
        }
        private bool isOrderPushSwitchToggled;     //Bool to define whether the "Order Push Notifications" setting is toggled
        public bool IsOrderPushSwitchToggled {
            get => isOrderPushSwitchToggled;
            set {
                isOrderPushSwitchToggled = value;
                ToggleSwitchSetting( UserSettings.SettingTypes.OrderPushNotifications.ToString(), IsOrderPushSwitchToggled );
                OnPropertyChanged( "IsOrderPushSwitchToggled" );
            }
        }
        private bool isOrderEmailSwitchToggled;     //Bool to define whether the "Order Email Notifications" setting is toggled
        public bool IsOrderEmailSwitchToggled {
            get => isCouponEmailSwitchToggled;
            set {
                isOrderEmailSwitchToggled = value;
                ToggleSwitchSetting( UserSettings.SettingTypes.OrderEmailNotifications.ToString(), isOrderEmailSwitchToggled );
                OnPropertyChanged( "IsOrderEmailSwitchToggled" );
            }
        }
        private bool isDeliveryPushSwitchToggled;     //Bool to define whether the "Delivery Push Notifications" setting is toggled
        public bool IsDeliveryPushSwitchToggled {
            get => isDeliveryPushSwitchToggled;
            set {
                isDeliveryPushSwitchToggled = value;
                ToggleSwitchSetting( UserSettings.SettingTypes.DeliveryPushNotifications.ToString(), isDeliveryPushSwitchToggled );
                OnPropertyChanged( "IsDeliveryPushSwitchToggled" );
            }
        }
        private bool isDeliveryEmailSwitchToggled;     //Bool to define whether the "Delivery Email Notifications" setting is toggled
        public bool IsDeliveryEmailSwitchToggled {
            get => isDeliveryEmailSwitchToggled;
            set {
                isDeliveryEmailSwitchToggled = value;
                ToggleSwitchSetting( UserSettings.SettingTypes.DeliveryEmailNotifications.ToString(), isDeliveryEmailSwitchToggled );
                OnPropertyChanged( "IsDeliveryEmailSwitchToggled" );
            }
        }

        /* Commands */
        public ICommand NavigateBackCommand { get; set; }

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public NotificationsViewModel() {
            Title = "Notifications View";       //Set the title for this view
            UserRealName = UserContainer.CurrentUser.FullName;
             
            InitializeBindableProperties();     //Initialize the properties visible in the UI

            /* Command Initialization */
            NavigateBackCommand = new Command( () => App.SetCurrentPage<SettingsPage>() );
        }

        /// <summary>
        /// ToggleSwitchSetting:
        ///
        /// Takes the name of a UserSettings property and a value,
        /// then finds that property by name and sets it to value.
        /// Then writes the modified userSettings object to settings file as JSON.
        /// </summary>
        /// <param name="settingProperty"> The name of the property to set on userSettings </param>
        /// <param name="value"> The bool value to assign the property </param>
        void ToggleSwitchSetting( string settingProperty, bool value ) {
            Type objectType = SettingsContainer.Instance.CurrentUserSettings.GetType();      //Get the Type of both userSettings
            PropertyInfo objectPropertyInfo = objectType.GetProperty( settingProperty );        //Get the property to set from UserSettings

            if ( objectPropertyInfo != null && objectPropertyInfo.CanWrite ) {
                objectPropertyInfo.SetValue( SettingsContainer.Instance.CurrentUserSettings, value, null );      //Set the value of userSettings
            }
            /* Create and Write the modified Settings to the JSON settings file */
            jsonObject = JObject.FromObject( SettingsContainer.Instance.CurrentUserSettings );        //Create JSON object from userSettings
            SerializationHelper.JsonWrite( SettingsContainer.SettingsFilePath, jsonObject.ToString() );       //Write the JSON object to the settings file
        }

        /// <summary>
        /// InitializeUserSettings:
        ///
        /// Sets the bindable properties in this view to the global
        /// user settings. Used to initialize the values of the settings in this view.
        /// </summary>
        void InitializeBindableProperties() {
            isCouponPushSwitchToggled = SettingsContainer.Instance.CurrentUserSettings.CouponPushNotifications;
            isCouponEmailSwitchToggled = SettingsContainer.Instance.CurrentUserSettings.CouponEmailNotifications;
            isOrderPushSwitchToggled = SettingsContainer.Instance.CurrentUserSettings.OrderPushNotifications;
            isOrderEmailSwitchToggled = SettingsContainer.Instance.CurrentUserSettings.OrderEmailNotifications;
            isDeliveryPushSwitchToggled = SettingsContainer.Instance.CurrentUserSettings.DeliveryPushNotifications;
            isDeliveryEmailSwitchToggled = SettingsContainer.Instance.CurrentUserSettings.DeliveryEmailNotifications;
        }

        #endregion
    }
}
