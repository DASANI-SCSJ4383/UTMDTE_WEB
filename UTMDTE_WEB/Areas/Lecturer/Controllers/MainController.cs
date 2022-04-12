using Microsoft.AspNetCore.Mvc;

namespace UTMDTE_WEB.Areas.Lecturer.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
