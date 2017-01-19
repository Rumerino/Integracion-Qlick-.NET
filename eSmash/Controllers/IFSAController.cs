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
    
    public class IFSAController : AbstractDemoController
    {
        //private BBDD bbdd = new Models.BBDD();
        // GET: ISA
        public IFSAController()
        {
            App = new Qlik.IFSA();

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
        public ActionResult APAnalysis()
        {
            return View(getViewModelWithFilter(App["APAnalysis"]));
        }
        

        public ActionResult Glossary()
        {
            return View("~/Views/IFSA/Glossary.cshtml");
        }

        public ActionResult NavBarTop()
        {
            var parentRouteValues =
                ControllerContext.ParentActionViewContext.RouteData.Values;

            return View(parentRouteValues);
        }

        public ActionResult NavBarBottom()
        {
            return View("~/Views/IFSA/NavBarBottom.cshtml");
        }

        public ActionResult QlikGeneric()
        {
            return View(getViewModelWithFilter(App["market"]));
        }

        public AccountVals account(string idAcc, string idUsr)
        {
            

            AccountVals userAcc = new AccountVals();
            userAcc.id = idUsr;



            string query = "select distinct aus.userid, aus.accountid, a.accountdescription, s.dataanalysis, s.datatypeid from admin.account_user_source aus, admin.account a, admin.source s where aus.accountid = a.accountid and aus.sourceid = s.sourceid AND aus.accountid =" + idAcc + "AND  aus.userid= " + idUsr;
            eSmash.Controllers.eSmashController e = new eSmash.Controllers.eSmashController();
            userAcc.acounts = e.getAccount(idUsr, idAcc);

            return userAcc;
        }


        //public List<accounts> getAccounts(String idUser, String idAccount)
        //{

        //    try
        //    {

        //        string query = "";
        //        if (idAccount == "")
        //        {
        //            query = "select ass.userid,  ass.accountid, a.accountdescription from  admin.account_user_asso ass left join admin.account a on ass.accountid = a.accountid WHERE ass.userid = '" + idUser + "'";
        //        }
        //        else
        //        {
        //            query = "select ass.userid,  ass.accountid, a.accountdescription from  admin.account_user_asso ass left join admin.account a on ass.accountid = a.accountid WHERE ass.userid = '" + idUser + "' AND ass.accountid = '" + idAccount + "'";
        //        }

        //        return bbdd.getAccounts(query);

        //    }
        //    catch (Exception)
        //    {
        //        // something went wrong, and you wanna know why
        //        return new List<accounts>();
        //    }
        //}
    }

}