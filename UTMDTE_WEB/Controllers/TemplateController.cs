using Microsoft.AspNetCore.Mvc;

namespace UTMDTE.Controllers
{
    public class TemplateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error500()
        {
            return View();
        }

        public IActionResult Blank()
        {
            return View();
        }

        public IActionResult Charts()
        {
            return View();
        }

        public IActionResult Colors()
        {
            return View();
        }

        public IActionResult Docs()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Typography()
        {
            return View();
        }

        public IActionResult Widgets()
        {
            return View();
        }

        //Base
        public IActionResult Accordion()
        {
            return View("/Views/Template/Base/Accordion.cshtml");
        }

        public IActionResult Breadcrumb()
        {
            return View("/Views/Template/Base/Breadcrumb.cshtml");
        }

        public IActionResult Cards()
        {
            return View("/Views/Template/Base/Cards.cshtml");
        }

        public IActionResult Carousel()
        {
            return View("/Views/Template/Base/Carousel.cshtml");
        }

        public IActionResult Collapse()
        {
            return View("/Views/Template/Base/Collapse.cshtml");
        }

        public IActionResult ListGroup()
        {
            return View("/Views/Template/Base/ListGroup.cshtml");
        }

        public IActionResult Navs()
        {
            return View("/Views/Template/Base/Navs.cshtml");
        }

        public IActionResult Pagination()
        {
            return View("/Views/Template/Base/Pagination.cshtml");
        }

        public IActionResult Placeholders()
        {
            return View("/Views/Template/Base/Placeholders.cshtml");
        }

        public IActionResult Popovers()
        {
            return View("/Views/Template/Base/Popovers.cshtml");
        }

        public IActionResult Progress()
        {
            return View("/Views/Template/Base/Progress.cshtml");
        }

        public IActionResult Scrollspy()
        {
            return View("/Views/Template/Base/Scrollspy.cshtml");
        }

        public IActionResult Spinners()
        {
            return View("/Views/Template/Base/Spinners.cshtml");
        }

        public IActionResult Tables()
        {
            return View("/Views/Template/Base/Tables.cshtml");
        }

        public IActionResult Tabs()
        {
            return View("/Views/Template/Base/Tabs.cshtml");
        }

        public IActionResult Tooltips()
        {
            return View("/Views/Template/Base/Tooltips.cshtml");
        }

        //Buttons
        public IActionResult ButtonsGroup()
        {
            return View("/Views/Template/Buttons/ButtonsGroup.cshtml");
        }

        public IActionResult Buttons()
        {
            return View("/Views/Template/Buttons/Buttons.cshtml");
        }

        public IActionResult Dropdowns()
        {
            return View("/Views/Template/Buttons/Dropdowns.cshtml");
        }

        //Forms
        public IActionResult ChecksAndRadios()
        {
            return View("/Views/Template/Forms/ChecksAndRadios.cshtml");
        }

        public IActionResult FloatingLabels()
        {
            return View("/Views/Template/Forms/FloatingLabels.cshtml");
        }

        public IActionResult FormControl()
        {
            return View("/Views/Template/Forms/FormControl.cshtml");
        }

        public IActionResult InputGroup()
        {
            return View("/Views/Template/Forms/InputGroup.cshtml");
        }

        public IActionResult Layout()
        {
            return View("/Views/Template/Forms/Layout.cshtml");
        }

        public IActionResult Range()
        {
            return View("/Views/Template/Forms/Range.cshtml");
        }

        public IActionResult Select()
        {
            return View("/Views/Template/Forms/Select.cshtml");
        }

        public IActionResult Validation()
        {
            return View("/Views/Template/Forms/Validation.cshtml");
        }

        //Icons
        public IActionResult IconsBrand()
        {
            return View("/Views/Template/Icons/IconsBrand.cshtml");
        }

        public IActionResult IconsFlags()
        {
            return View("/Views/Template/Icons/IconsFlags.cshtml");
        }

        public IActionResult IconsFree()
        {
            return View("/Views/Template/Icons/IconsFree.cshtml");
        }

        //Notifications
        public IActionResult Alerts()
        {
            return View("/Views/Template/Notifications/Alerts.cshtml");
        }

        public IActionResult Badge()
        {
            return View("/Views/Template/Notifications/Badge.cshtml");
        }

        public IActionResult Modals()
        {
            return View("/Views/Template/Notifications/Modals.cshtml");
        }

        public IActionResult Toasts()
        {
            return View("/Views/Template/Notifications/Toasts.cshtml");
        }
    }
}
