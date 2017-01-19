using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSmash.Models.View;
using eSmash.Qlik;
using QlikSense;
using eSmash.Util;
using eSmash.Models;

namespace eSmash.Controllers
{
    public abstract class AbstractDemoController : Controller
    {
        protected QlikApp App { get; set; }

        protected AccountVals Account { get; set; }

        protected QlikApplication getViewModel(
            QlikSheet sheet, params QlikVisualization[] filterPanels)
        {
            var model = new QlikApplication(App,new UserApplication().serverRootUrl);

            model.Sheet = sheet;

            
               

            foreach (var filterPanel in filterPanels)
            {
                model.FilterPanels.Add(filterPanel);
            }

            return model;
        }
    }
}