using System.Collections.Generic;
using Xamarin.Forms;

namespace TopShelfCustomer.Services {

    /// <summary>
    /// PageContainer:
    ///
    /// Static class for managing Page instances
    /// </summary>
    public static class PageContainer {

        #region Properties

        public static List<Page> Views { get; set; }        //List of Pages

        #endregion Properties

        static PageContainer () {
            /* Initialize View list */
            if ( Views == null ) {
                Views = new List<Page> {
                    Application.Current.MainPage
                };
            }
        }
    }
}