using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QlikSense;
using eSmash.Models.View;
using eSmash.Models;

namespace eSmash.Controllers
{
    
    public class ISAController : AbstractDemoController
    {
        //private BBDD bbdd = new Models.BBDD();
        // GET: ISA
        public ISAController()
        {
            App = new Qlik.ISA();

            Account = account("63", "130");
        }
        public ActionResult Index()
        {
            return RedirectToAction("market", this.RouteData.Values);
        }

        private QlikApplication getViewModelWithFilter(QlikSheet sheet)
        {
            return getViewModel(sheet, App["market"]["FilterPane_Filters_1"], App["market"]["FilterPane_Filters_2"], App["market"]["FilterPane_Filters_3"], App["market"]["FilterPane_Filters_General"], App["market"]["FilterPane_Filters_Agent"], App["market"]["FilterPane_Filters_OD"], App["market"]["FilterPane_Filters_Other"]);
        }

        public ActionResult market()
        {
            return View(getViewModelWithFilter(App["market"]));
        }
        public ActionResult Passengers()
        {
            return View(getViewModelWithFilter(App["Passengers"]));
        }

        public ActionResult Yield()
        {
            return View(getViewModelWithFilter(App["Yield"]));
        }

        public ActionResult Revenue()
        {
            return View(getViewModelWithFilter(App["Revenue"]));
        }
        public ActionResult route()
        {
            return View(getViewModelWithFilter(App["route"]));
        }
        public ActionResult routepassenger()
        {
            return View(getViewModelWithFilter(App["routepassenger"]));
        }
        public ActionResult agentrpassenger()
        {
            return View(getViewModelWithFilter(App["agentrpassenger"]));
        }
        public ActionResult agentrevenue()
        {
            return View(getViewModelWithFilter(App["agentrevenue"]));
        }
        public ActionResult classAnalysis()
        {
            return View(getViewModelWithFilter(App["classAnalysis"]));
        }
        public ActionResult performance()
        {
            return View(getViewModelWithFilter(App["performance"]));
        }
        public ActionResult reporting()
        {
            return View(getViewModelWithFilter(App["reporting"]));
        }

        public ActionResult Glossary()
        {
            return View("~/Views/ISA/Glossary.cshtml");
        }

        public ActionResult NavBarTop()
        {
            var parentRouteValues =
                ControllerContext.ParentActionViewContext.RouteData.Values;

            return View(parentRouteValues);
        }

        public ActionResult NavBarBottom()
        {
            return View("~/Views/ISA/NavBarBottom.cshtml");
        }

        public ActionResult QlikGeneric()
        {
            return View(getViewModelWithFilter(App["market"]));
        }

        public AccountVals account(string idAcc, string idUsr)
        {
            

            AccountVals userAcc = new AccountVals();
            userAcc.id = idUsr;



             eSmash.Controllers.eSmashController e = new eSmash.Controllers.eSmashController();
            userAcc.acounts = e.getAccount(idUsr, idAcc);

            return userAcc;
        }


       
    }

}