using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Services;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// NotificationsViewModel:
    ///
    /// Allows the Notifications Settings View to communicate with the model classes.
    /// Also allows binding between XAML properties and code.
    /// </summary>
    public class NotificationsViewModel : BaseViewModel {

        #region Properties

        private JObject jsonObject = new JObject();     //Reusable JSON object

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

        /* Commands */
        public ICommand NavigateBackCommand { get; set; }

        #endregion Properties

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public NotificationsViewModel () {
            Title = "Notifications View";       //Set the title for this view

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
        private void ToggleSwitchSetting ( string settingProperty, bool value ) {
            string currentUserSettingPath = SettingsContainer.SettingsFilePath + UserContainer.CurrentUser.Id;
            Type objectType = SettingsContainer.CurrentUserSettings.GetType();      //Get the Type of both userSettings
            PropertyInfo objectPropertyInfo = objectType.GetProperty( settingProperty );        //Get the property to set from UserSettings

            if ( objectPropertyInfo != null && objectPropertyInfo.CanWrite ) {
                objectPropertyInfo.SetValue( SettingsContainer.CurrentUserSettings, value, null );      //Set the value of userSettings
            }
            /* Create and Write the modified Settings to the JSON settings file */
            jsonObject = JObject.FromObject( SettingsContainer.CurrentUserSettings );        //Create JSON object from userSettings
            SerializationHelper.JsonWrite( currentUserSettingPath, jsonObject.ToString() );       //Write the JSON object to the settings file
        }

        /// <summary>
        /// InitializeUserSettings:
        ///
        /// Sets the bindable properties in this view to the global
        /// user settings. Used to initialize the values of the settings in this view.
        /// </summary>
        private void InitializeBindableProperties () {
            isCouponPushSwitchToggled = SettingsContainer.CurrentUserSettings.CouponPushNotifications;
            isCouponEmailSwitchToggled = SettingsContainer.CurrentUserSettings.CouponEmailNotifications;
            isOrderPushSwitchToggled = SettingsContainer.CurrentUserSettings.OrderPushNotifications;
            isOrderEmailSwitchToggled = SettingsContainer.CurrentUserSettings.OrderEmailNotifications;
        }

        #endregion Class Methods
    }
}