using Microsoft.AspNetCore.Mvc;

namespace UTMDTE_WEB.Areas.UTMLeadAdministrator.Controllers
{
    [Area("UTMLeadAdministrator")]
    public class MainController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
