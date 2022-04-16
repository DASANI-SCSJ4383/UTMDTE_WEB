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

        public async Task<IActionResult> IndexAsync(int? CourseID)
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
                response = await RESTFulRequest.GetAsync($"lecturer/form/list/{CourseID}", accessToken);
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
                List<Form> forms = JsonSerializer.Deserialize<List<Form>>(response!["forms"]!.ToJsonString(), options)!;
                Course course = JsonSerializer.Deserialize<Course>(response!["course"]!.ToJsonString(), options)!;

                FormsViewModel modal = new FormsViewModel(forms, course);

                return View(modal);
            }
        }

        public async Task<IActionResult> ViewAsync(int? CourseID, int? id)
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
                response = await RESTFulRequest.GetAsync($"lecturer/form/view/{id}", accessToken);
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
                Form form = JsonSerializer.Deserialize<Form>(response!["form"]!.ToJsonString(), options)!;

                FormViewModel modal = new FormViewModel(form, CourseID);

                return View(modal);
            }
        }
    }
}
