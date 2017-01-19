using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSmash.Models;
using Npgsql;
using System.Web.Script.Serialization;

namespace eSmash.Controllers
{

    public class eSmashController : Controller
    {
        public eSmashController()
        {


        }

        //private BBDD bbdd = new Models.BBDD();
        // GET: eSmash
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Aplications()
        {

            HttpCookie cookie = HttpContext.Request.Cookies.Get("eSmashClient");
            if (cookie == null)
            {
                return View("~/Views/eSmash/index.cshtml");
            }

            return View();
        }


        public ActionResult loadImage()
        {
            Boolean app = getAplications(Request.Cookies["eSmashClientid"].Value);
            try
            {
                if (app)
                {
                    return Json("2");
                }
                else
                {
                    return Json("44");
                }

            }
            catch (Exception)
            {
                return Json("2");
            }
        }

        public ActionResult appAccount()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("eSmashClient");
            if (cookie == null)
            {
                return View("~/Views/eSmash/index.cshtml");
            }
            string id = Request.Cookies["eSmashClientid"].Value;
            UserAccounts userAcc = new UserAccounts();
            userAcc.id = id;
            userAcc.acounts = getAccounts(id, "");



            return View(userAcc);
        }

        public ActionResult account(string idAcc, string idUsr)
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("eSmashClient");
            if (cookie == null)
            {
                return View("~/Views/eSmash/index.cshtml");
            }

            AccountVals userAcc = new AccountVals();
            userAcc.id = idUsr;
            userAcc.acounts = getAccounts(idUsr, idAcc);
            userAcc.AFSA = true;
            userAcc.ASA = true;
            userAcc.ISA = true;
            userAcc.IFSA = true;
              
            //userAcc = bbdd.getAccountUses(userAcc, query);

            return PartialView("account", userAcc);
        }

        public accounts accounts(string idAcc, string idUsr)
        {
            accounts acount = new accounts();

            acount.id = idUsr;
            acount.idDiv = "buttondiv" + idAcc;
            acount.idAction = idAcc;
            acount.nombre = "example";
            acount.titulo = "Air-Berlin";
            acount.descripcion = "Berlin";


            return acount;
        }

        public Boolean getAplications(String id)
        {

            try
            {

              
                //return bbdd.foundAplication(query);
                return true;
            }
            catch (Exception)
            {
                // something went wrong, and you wanna know why
                return false;
            }
        }
        public List<accounts> getAccounts(String idUser, String idAccount)
        {

            try
            {
                List<accounts> n = new List<accounts>();
                //string query = "";
                //if (idAccount == "")
                //{
                //}
                //else
                //{
                //}

                //return bbdd.getAccounts(query);
                for (int i = 0; i < 4; i++){
                    n.Add(accounts(idAccount, idUser));
                }
                return n;
                
            }
            catch (Exception)
            {
                // something went wrong, and you wanna know why
                return new List<accounts>();
            }
        }
        public List<accounts> getAccount(String idUser, String idAccount)
        {

            try
            {
                List<accounts> n = new List<accounts>();
                //string query = "";
                //if (idAccount == "")
                //{
                //}
                //else
                //{
               //}

                //return bbdd.getAccounts(query);
                for (int i = 0; i < 1; i++)
                {
                    n.Add(accounts(idAccount, idUser));
                }
                return n;

            }
            catch (Exception)
            {
                // something went wrong, and you wanna know why
                return new List<accounts>();
            }
        }

        [HttpPost]
        public ActionResult login(String login, String password)
        {
            
            //string error = "Incorrect login";
            //if (bbdd.loggin(query))
            //{
          
            //ViewBag.ErrorMessage = null;
            //HttpCookie cookie = new HttpCookie("eSmashClient", login);
            //HttpCookie cookieId = new HttpCookie("eSmashClientId", bbdd.getIdUser(query2));
            ////HttpCookie cookie = HttpContext.Request.Cookies.Get("eSmashClient");
            ////cookie.Value = login;
            //HttpContext.Response.SetCookie(cookie);
            //HttpContext.Response.SetCookie(cookieId);
            //return View("~/Views/eSmash/aplications.cshtml");

            //}
            if (1==1)
            {
                ViewBag.ErrorMessage = null;
                HttpCookie cookie = new HttpCookie("eSmashClient", login);
                HttpCookie cookieId = new HttpCookie("eSmashClientId", "130");
                HttpContext.Response.SetCookie(cookie);
                HttpContext.Response.SetCookie(cookieId);
                return View("~/Views/eSmash/aplications.cshtml");
            }
               
            else
            {
                ViewBag.ErrorMessage = "Incorrect login";

                return View("~/Views/eSmash/Index.cshtml");
            }

        }

        public ActionResult loggout()
        {

            if (Request.Cookies["eSmashClient"] != null)
            {
                var c = new HttpCookie("eSmashClient");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
                 c = new HttpCookie("eSmashClientId");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            return View("~/Views/eSmash/Index.cshtml");
            

        }

        public AccountVals accountQlik()
        {
            string idUsr = "130";
            string idAcc = "63";
            AccountVals userAcc = new AccountVals();
            userAcc.id = idUsr;
            userAcc.AFSA = true;
            userAcc.ASA = true;
            userAcc.ISA = true;
            userAcc.IFSA = true;
            userAcc.acounts = getAccount(idUsr, idAcc);


         
            //userAcc = bbdd.getAccountUses(userAcc, query);

            return userAcc;
        }
        public ActionResult NavBarTop()
        {

           
            return View("~/Views/ISA/NavBarTop.cshtml", accountQlik());


        }

        public ActionResult NavBarTop2()
        {


            return View("~/Views/IFSA/NavBarTop.cshtml", accountQlik());


        }


    }
}