﻿using System;
using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Services;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// PaymentViewModel:
    ///
    /// ViewModel for the PaymentView.
    /// Allows the UI to interact with the Models directly.
    /// </summary>
    public class PaymentViewModel : BaseViewModel {

        private string streetAddress;
        public string StreetAddress {
            get => streetAddress;
            set {
                streetAddress = value;
                OnPropertyChanged( "StreetAddress" );
            }
        }

        private int zipCode;
        public int ZipCode {
            get => zipCode;
            set {
                zipCode = value;
                OnPropertyChanged( "ZipCode" );
            }
        }

        private int cardNumber;
        public int CardNumber {
            get => cardNumber;
            set {
                cardNumber = value;
                OnPropertyChanged( "CardNumber" );
            }
        }

        private int cvv;
        public int CVV {
            get => cvv;
            set {
                cvv = value;
                OnPropertyChanged( "CVV" );
            }
        }

        private string expDate;
        public string ExpDate {
            get => expDate;
            set {
                expDate = value;
                OnPropertyChanged( "ExpDate" );
            }
        }
        public TimeSpan StartTime { get; set; } = new TimeSpan( DateTime.Now.Hour + 1, DateTime.Now.Minute + 15, DateTime.Now.Second );
        public TimeSpan EndTime { get; set; } = new TimeSpan( DateTime.Now.Hour + 2, DateTime.Now.Minute + 15, DateTime.Now.Second );

        /* Initialize Commands */
        public ICommand NavigateBackCommand { get; }
        public ICommand PlaceOrderCommand { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public PaymentViewModel() {
            Title = "Payment";
            InitializePaymentView();

            /* Initialize Commands */
            NavigateBackCommand = new Command( () => App.SetCurrentPage<CheckoutView>() );
            PlaceOrderCommand = new Command( PlaceOrder );
        }

        /// <summary>
        /// InitializePaymentView:
        ///
        /// Sets the bindable properties on this view.
        /// </summary>
        void InitializePaymentView() {
            StreetAddress = UserContainer.CurrentUser.StreetAddress;
            ZipCode = UserContainer.CurrentUser.ZipCode;
        }

        /// <summary>
        /// PlaceOrder:
        ///
        /// Handler for the Place Order
        /// button. Called from PlaceOrderCommand
        /// Command delegate.
        /// </summary>
        void PlaceOrder() {
            OrderReceipt order = new OrderReceipt {     //Construct OrderReceipt to write to database
                Date = DateTime.Now,
                DriverName = "George",
                EmailAddress = UserContainer.CurrentUser.EmailAddress,
                LastFour = int.Parse( CardNumber.ToString().Substring( CardNumber.ToString().Length - 4 ) ),
                NumItems = UserContainer.UserCart.Items.Count,
                Price = UserContainer.UserCart.Price,
                StoreName = UserContainer.CurrentUser.StoreName };
            UserContainer.Orders.Add( order );
            App.SetCurrentPage<OrderHistoryView>();
        }
    }
}
