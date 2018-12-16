using System.Web.Mvc;

namespace AngularJStore.App.Controllers
{
    public class HtmlController : Controller
    {
        public ActionResult Home()
        {
            return PartialView();
        }

        public ActionResult Customers()
        {
            return PartialView();
        }

        public ActionResult Orders()
        {
            return PartialView();
        }
    }
}