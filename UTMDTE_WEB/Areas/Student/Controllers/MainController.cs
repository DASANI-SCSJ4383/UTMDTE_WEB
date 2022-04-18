using Microsoft.AspNetCore.Mvc;

namespace UTMDTE_WEB.Areas.Student.Controllers
{
    [Area("Student")]
    public class MainController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
