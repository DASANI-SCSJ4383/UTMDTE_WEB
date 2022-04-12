using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using UTMDTE.API;
using UTMDTE_WEB.API;
using UTMDTE_WEB.Areas.UTMLeadAdministrator.Models;
using UTMDTE_WEB.Models;

namespace UTMDTE_WEB.Areas.UTMLeadAdministrator.Controllers
{
    [Area("UTMLeadAdministrator")]
    public class FormController : Controller
    {
        private readonly RESTFulRequest RESTFulRequest;

        public FormController(RESTFulRequest restFulRequest)
        {
            RESTFulRequest = restFulRequest;
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
                response = await RESTFulRequest.GetAsync("utmleadAdministrator/form", accessToken);
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
                List<Form> forms = JsonSerializer.Deserialize<List<Form>>(response!["forms"]!.ToJsonString(), options);

                FormViewModel model = new FormViewModel(new Form(), forms);

                return View(model);
            }
        }

        public async Task<IActionResult> CreateAsync(FormViewModel formViewModel)
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
                response = await RESTFulRequest.PostAsync("utmleadAdministrator/form", formViewModel.Form, accessToken);
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
                TempData["AlertMessage"] = $"{formViewModel.Form.Title.ToUpper()} successfully save in the system";

                return RedirectToAction("Index");
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
                response = await RESTFulRequest.GetAsync($"utmleadAdministrator/form/{id}", accessToken);
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
                Form modal = JsonSerializer.Deserialize<Form>(response!["form"]!.ToJsonString(), options);

                return View(modal);
            }
        }

        public async Task<IActionResult> UpdateAsync(Form form, int? id)
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
                response = await RESTFulRequest.PatchAsync($"utmleadAdministrator/form/{id}", form, accessToken);
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
                TempData["AlertMessage"] = $"{form.Title.ToUpper()} successfully updated in the system";

                return RedirectToAction("View", "Form", new {area = "UTMLeadAdministrator", id = form.ID});
            }
        }

        public async Task<IActionResult> DeleteAsync(int? id)
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
                response = await RESTFulRequest.DeleteAsync($"utmleadAdministrator/form/{id}", accessToken);
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
                TempData["AlertMessage"] = "The form has successfully deleted in the system";

                return RedirectToAction("Index");
            }
        }
    }
}
