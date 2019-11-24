using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.ComponentModel;

namespace TopShelfCustomer.Models {

    /// <summary>
    /// StoreDisplay:
    ///
    /// Responsible for exposing Store data to a ViewModel.
    /// Exposes specific properties of a Store and handles Property changes from the associated View.
    /// </summary>
    public sealed class StoreDisplay: INotifyPropertyChanged {

        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;       //PropertyChanged event to permeate property changes to the UI

        public Store StoreToDisplay { get; set; }       //The Store that this StoreDisplay is exposing

        /* Bindable Properties */
        public string Name { get; set; }        //The Store name
        public string Address { get; set; }     //The Store address
        public UriImageSource StoreImage { get; set; }      //The Store image

        private bool isSelected;        //Bool value to determine whether to show more info for this Store
        public bool IsSelected {
            get {
                return isSelected;
            }
            set {
                isSelected = value;
                RaiseProperty( "IsSelected" );
            }
        }

        public ICommand GetDirectionsCommand { get; }       //Command to open Maps app to correct Store address

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public StoreDisplay() {
            StoreImage = new UriImageSource { Uri = new Uri( "https://pbs.twimg.com/profile_images/1131606709313712129/H5XKewbN.png" ) };        //FIXME: Remove this after we can fetch Store-specific images
            GetDirectionsCommand = new Command( () => Map.OpenAsync( new Location( 29.576320, -98.619990 ) ) );     //Initialize GetDirectionsCommand to open random long-lat coordinates FIXME: get actual lat/long of each Store
        }

        /// <summary>
        /// RaiseProperty:
        ///
        /// PropertyChanged event handler.
        /// Raises a PropertyChanged event on the passed Property name.
        /// </summary>
        /// <param name="name"> The property to raise the event for </param>
        public void RaiseProperty( string name ) => PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( name ) );

        #endregion
    }
}
