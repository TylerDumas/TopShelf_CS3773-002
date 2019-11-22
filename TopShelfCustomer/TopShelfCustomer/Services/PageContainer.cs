using System;
using System.Windows.Input;
using System.Diagnostics;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;
using Xamarin.Forms;
using System.ComponentModel;
using Xamarin.Essentials;
using System.Collections.Generic;

namespace TopShelfCustomer.Services {

    /// <summary>
    /// PageContainer:
    ///
    /// Static class for managing Page instances
    /// </summary>
    public static class PageContainer {

        #region Properties

        public static List<Page> Views { get; set; }        //List of Pages

        #endregion

        static PageContainer() {

            /* Initialize View list */
            if( Views == null ) {
                Views = new List<Page> {
                    Application.Current.MainPage
                };
            }
        }
    }
}
