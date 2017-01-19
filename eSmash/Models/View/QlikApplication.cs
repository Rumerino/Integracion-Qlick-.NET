using eSmash.Util;
using QlikSense;
using System.Collections.Generic;
using System.Web;
using System;
using System.Web.Mvc;
using eSmash.Models;
using Npgsql;
using eSmash.Qlik;
using Newtonsoft.Json;


namespace eSmash.Models.View
{
    public class QlikApplication
    {
        public QlikApp App { get; set; }
        public QlikSheet Sheet { get; set; }
        public IList<QlikVisualization> FilterPanels { get; set; }
        public string urlBase { get; set; }

        public string hostName { get; set; }
        public string DomainName { get; set; }
        public string vProxy { get; set; }

        public AccountVals Account { get; set; }

        public QlikApplication(QlikApp app)
        {
            App = app;

           

            FilterPanels = new List<QlikVisualization>();
        }
        public QlikApplication(QlikApp app, string url)
        {
            this.urlBase = url;
            App = app;
            FilterPanels = new List<QlikVisualization>();

            hostName = ConfigReader.getQlikConfigValue("uriBase");
            vProxy = ConfigReader.getQlikConfigValue("virtualProxy");
            DomainName = ConfigReader.getQlikConfigValue("webDomain");


            eSmash.Controllers.eSmashController e = new eSmash.Controllers.eSmashController();
            Account = e.accountQlik();




        }


    }
}