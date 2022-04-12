using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json.Nodes;
using UTMDTE.API;
using UTMDTE_WEB.Models;

namespace UTMDTE_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RESTFulRequest _RESTFulRequest;

        public HomeController(ILogger<HomeController> logger, RESTFulRequest restfulRequest)
        {
            _logger = logger;
            _RESTFulRequest = restfulRequest;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _RESTFulRequest.PostAsync("authentication", loginViewModel);

                if (response == null)
                {
                    TempData["AlertType"] = "error";
                    TempData["AlertMessage"] = "Invalid Username and Password, Please Try Again";

                    return View();
                }
                else
                {
                    HttpContext.Session.SetString("accessToken", response!["access_token"]!.ToString());
                    return RedirectToAction("Dashboard", "Main", new { area = response!["userType"]!.ToString() });
                }
            }

            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}