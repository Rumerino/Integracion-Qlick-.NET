using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSmash.Util;
using QlikSense;
using eSmash.Models;

namespace eSmash.Controllers
{

    public class QlikController : Controller
    {
        
    // GET: Qlik
    public ActionResult Index()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("eSmashClient");
            if (cookie == null)
            {
                return View("~/Views/eSmash/index.cshtml");
            }

            UserApplication application = new UserApplication();
            Application app = application.Start();

            QlikModel model = new QlikModel()
            {
                ticket = app.Ticket,
                url = application.serverRootUrl
            };
            return View(model);
        }
    }
}