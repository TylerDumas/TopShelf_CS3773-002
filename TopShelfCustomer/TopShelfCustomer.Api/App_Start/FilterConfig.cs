using System.Web.Mvc;

namespace TopShelfCustomer.Api {

    public class FilterConfig {

        public static void RegisterGlobalFilters ( GlobalFilterCollection filters ) {
            filters.Add( new HandleErrorAttribute() );
        }
    }
}