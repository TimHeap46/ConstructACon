using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using App1.Models;
using App1.Models.Household;
using App1.Models.ViewModel;

namespace App1.Controllers
{
    public class HouseholdController : Controller
    {
        // GET: Household
        public ActionResult Index()
        {
            var providerList = GetProviders();

            var risk = GetRiskFromJourney();

            var vm = MapRiskToVM(risk);

            foreach (var provider in providerList)
            {
                vm.ProcessOverrides(provider.Value);

                var requestAfter = RenderViewToString(provider, vm);

                System.IO.File.WriteAllText(String.Format(@"c:\out\{0}.xml", provider.Value), requestAfter);
            }

            return View();
        }

        private object GetRiskFromJourney()
        {
            //DUMMY METHOD
            return null;
        }

        private HouseholdViewModel MapRiskToVM(object risk)
        {
            //Convert JSON/XML/?? to Vm?
            
            return HouseholdViewModelFactory.GiveMeAStubbedViewModel();
        }

        private IEnumerable<KeyValuePair<string, string>> GetProviders()
        {
            var providerList = new Dictionary<string, string>
            {
                {"Axa", "AXA"},
                {"providerTwo", "PRO2"},
                {"providerThree", "PRO3"},
                {"Esure", "ESU3"}
            };

            return providerList;
        }

        private string RenderViewToString(KeyValuePair<string, string> provider, HouseholdViewModel vm)
        {
            ViewData.Model = vm;
            var viewName = string.Format("~/Views/Household/{0}/Outgoing.cshtml", provider.Value);
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}