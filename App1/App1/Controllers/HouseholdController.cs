﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using App1.Models;

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
                vm.ProcessMappings(provider.Value);

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
            var vm = new HouseholdViewModel
            {
                CommencementDate = new DateTime(2014, 12, 25),
                QuoteReference = "a639807c-db93-42ec-bfea-3d90fbc03571",
                BuildingsCoverAmount = 700000,
                ContentsCoverAmount = 66001,
                CoverType = { ID = 3, Description = "BuildingsAndContents" },
                PropertyDetails =
                {
                    NumberOfBedrooms = 2,
                    YearBuilt = 2012,
                    IsListedBuilding = false,
                    ListedBuildingType = new KeyValue(){ID = 2, Description = "Who knows.. or cares"},
                    PropertyType = "House"
                },
                PolicyHolder = { FirstName = "Bob", LastName = "Smith", DateOfBirth = new DateTime(1978, 03, 30), EmailAddress = "moo@moo.com", MobilePhone = "07890999888" },
                ContentsAccidentalDamageCoverRequired = false,
                BuildingsAccidentalDamageCoverRequired = true,
                BuildingsVoluntaryExcess = "50",
                ContentsVoluntaryExcess = "100",
                YearsBuildingHeld = "3",
                YearsContentsHeld = "4"
            };
            vm.PolicyHolder.MaritalStatus = new KeyValue();
            vm.PolicyHolder.MaritalStatus.ID = 1;
            vm.PolicyHolder.MaritalStatus.Description = "Married";

            return vm;
        }

        private IEnumerable<KeyValuePair<string, string>> GetProviders()
        {
            var providerList = new Dictionary<string, string>();
            providerList.Add("Axa", "AXA");
            providerList.Add("providerTwo", "PRO2");
            providerList.Add("providerThree", "PRO3");

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