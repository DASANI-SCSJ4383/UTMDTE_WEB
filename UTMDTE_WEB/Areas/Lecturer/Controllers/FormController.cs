    using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using UTMDTE.API;

namespace UTMDTE_WEB.Areas.Lecturer.Controllers
{
    public class FormController : Controller
    {
        private readonly RESTFulRequest RESTFulRequest;

        public FormController(RESTFulRequest _RESTFulRequest)
        {
            RESTFulRequest = _RESTFulRequest;
        }

        public IActionResult Index()
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
                response = await RESTFulRequest.GetAsync("lecturer/form", accessToken);
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
            return View();
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
