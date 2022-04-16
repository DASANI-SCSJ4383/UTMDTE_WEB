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
    public class CourseController : Controller
    {
        private readonly RESTFulRequest RESTFulRequest;

        public CourseController(RESTFulRequest _RESTFulRequest)
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

        public async Task<IActionResult> SetFormAsync(int? id, int? FormID)
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
                dynamic data = new System.Dynamic.ExpandoObject();
                data.FormID = FormID;

                response = await RESTFulRequest.PatchAsync($"lecturer/course/set/{id}", data, accessToken);
            }

            if (response == null)
            {
                TempData["AlertType"] = "error";
                TempData["AlertMessage"] = "Internal Server Error Occur, Please Try Again";

                return Redirect(Request.Headers["Referer"].ToString());
            }
            else
            {
                TempData["AlertType"] = "success";
                TempData["AlertMessage"] = $"The form has been set successfully in the system";

                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> UnsetFormAsync(int? id)
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
                response = await RESTFulRequest.GetAsync($"lecturer/course/unset/{id}", accessToken);
            }

            if (response == null)
            {
                TempData["AlertType"] = "error";
                TempData["AlertMessage"] = "Internal Server Error Occur, Please Try Again";

                return Redirect(Request.Headers["Referer"].ToString());
            }
            else
            {
                TempData["AlertType"] = "success";
                TempData["AlertMessage"] = $"The form has been unset successfully in the system";

                return RedirectToAction("Index");
            }
        }
    }
}
