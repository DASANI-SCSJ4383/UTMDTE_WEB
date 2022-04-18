using Microsoft.AspNetCore.Mvc;

namespace UTMDTE_WEB.Areas.Student.Controllers
{
    [Area("Student")]
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
