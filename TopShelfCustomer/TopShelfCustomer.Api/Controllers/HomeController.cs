using System.Web.Mvc;

namespace TopShelfCustomer.Api.Controllers {

    /// <summary>
    /// HomeController:
    ///
    /// Default controller generated with ASP.NET project.
    /// </summary>
    public sealed class HomeController : Controller {

        /// <summary>
        /// Index:
        ///
        /// Default generated Method.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index () {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}