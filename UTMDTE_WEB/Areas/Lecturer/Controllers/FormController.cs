    using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using UTMDTE.API;
using UTMDTE_WEB.API;
using UTMDTE_WEB.Areas.Lecturer.Models;
using UTMDTE_WEB.Models;

namespace UTMDTE_WEB.Areas.Lecturer.Controllers
{
    [Area("Lecturer")]
    public class FormController : Controller
    {
        private readonly RESTFulRequest RESTFulRequest;

        public FormController(RESTFulRequest _RESTFulRequest)
        {
            RESTFulRequest = _RESTFulRequest;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var accessToken = HttpContext.Session.GetString("accessToken");

            JsonNode? response;
            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["AlertType"] = "info";
                TempData["AlertMessage"] = "Invalid Session. Please Login Again";

                return RedirectToAction("Logout", "Home", new { area = "" });
            }
            else
            {
                response = await RESTFulRequest.GetAsync("lecturer/course", accessToken);
            }

            if (response == null)
            {
                TempData["AlertType"] = "error";
                TempData["AlertMessage"] = "Internal Server Error Occur, Please Try Again";

                return Redirect(Request.Headers["Referer"].ToString());
            }
            else
            {
                var options = JsonSetting.GetDeserializeSetting();
                List<Course> courses = JsonSerializer.Deserialize<List<Course>>(response!["courses"]!.ToJsonString(), options)!;

                CourseViewModel modal = new CourseViewModel(courses);

                return View(modal);
            }
        }

        public IActionResult List(int? FormID)
        {


            return View();
        }

        public IActionResult Set(int? FormID)
        {
            return RedirectToAction("Index");
        }
    }
}
