using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using UTMDTE.API;
using UTMDTE_WEB.API;
using UTMDTE_WEB.Areas.UTMLeadAdministrator.Models;
using UTMDTE_WEB.Models;

namespace UTMDTE_WEB.Areas.UTMLeadAdministrator.Controllers
{
    [Area("UTMLeadAdministrator")]
    public class RubricController : Controller
    {
        private readonly RESTFulRequest RESTFulRequest;

        public RubricController(RESTFulRequest restFulRequest)
        {
            RESTFulRequest = restFulRequest;
        }

        public async Task<IActionResult> IndexAsync(int? formId)
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
                response = await RESTFulRequest.GetAsync($"utmleadAdministrator/rubric/list/{formId}", accessToken);
            }

            if (response == null)
            {
                TempData["AlertType"] = "error";
                TempData["AlertMessage"] = "Internal Server Error Occur, Please Try Again";

                return Redirect(Request.Headers["Referer"].ToString());
            }
            else
            {
                List<Rubric> rubrics = JsonConvert.DeserializeObject<List<Rubric>>(response!["rubrics"]!.ToJsonString())!;
                Form form = JsonConvert.DeserializeObject<Form>(response!["form"]!.ToJsonString())!;

                RubricViewModel model = new RubricViewModel(new Rubric(), rubrics, form);

                return View(model);
            }
        }

        public async Task<IActionResult> CreateAsync(int? formId, RubricViewModel rubricViewModel)
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
                response = await RESTFulRequest.PostAsync($"utmleadAdministrator/rubric/{formId}", rubricViewModel.Rubric, accessToken);
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
                TempData["AlertMessage"] = $"{rubricViewModel.Rubric.Description.ToUpper()} successfully save with this Form";

                return RedirectToAction("Index", "Rubric", new { area = "UTMLeadAdministrator", formId = formId});
            }
        }

        public async Task<IActionResult> ViewAsync(int? id)
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
                response = await RESTFulRequest.GetAsync($"utmleadAdministrator/rubric/view/{id}", accessToken);
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
                Rubric modal = JsonConvert.DeserializeObject<Rubric>(response!["rubric"]!.ToJsonString())!;

                return View(modal);
            }
        }

        public async Task<IActionResult> UpdateAsync(int? id, Rubric rubric)
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
                response = await RESTFulRequest.PatchAsync($"utmleadAdministrator/rubric/{id}", rubric, accessToken);
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
                TempData["AlertMessage"] = "The Rubric has been updated";

                return RedirectToAction("View", "Rubric", new { area = "UTMLeadAdministrator", id = rubric.ID });
            }
        }

        public async Task<IActionResult> DeleteAsync(int? id, int? formId)
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
                response = await RESTFulRequest.DeleteAsync($"utmleadAdministrator/rubric/{id}", accessToken);
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
                TempData["AlertMessage"] = "The Rubric has been deleted";

                return RedirectToAction("Index", "Rubric", new { area = "UTMLeadAdministrator", formId = formId });
            }
        }
    }
}
