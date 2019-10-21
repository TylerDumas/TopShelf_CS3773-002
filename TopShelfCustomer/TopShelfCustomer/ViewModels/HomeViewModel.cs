using System.Windows.Input;
using Xamarin.Forms;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;


namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// HomeViewModel:
    ///
    /// ViewModel for the Home page
    /// Allows the interface to connect to the model classes directly
    /// </summary>
    public class HomeViewModel : BaseViewModel {

        public string UserName { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeViewModel() {
            Title = "Home";

            /* Temporary User to test name display */
            User temp = new User();
            temp.Name = "Jackson";
            UserName = temp.Name;
        }
    }
}
