using System;
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
            var vm = new HouseholdViewModel
            {
                CommencementDate = new DateTime(2014, 12, 25),
                QuoteReference = "a639807c-db93-42ec-bfea-3d90fbc03571",
                BuildingsCoverAmount = 700000,
                ContentsCoverAmount = 66001,
                CoverType =
                {
                    ID = 3,
                    Description = "BuildingsAndContents"
                },
                PropertyDetails =
                {
                    NumberOfBedrooms = 2,
                    YearBuilt = 2012,
                    IsListedBuilding = false,
                    ListedBuildingType = new KeyValue()
                    {
                        ID = 2,
                        Description = "Who knows.. or cares"
                    },
                    PropertyType = "House",
                    OccupancyStatus = new KeyValue()
                    {
                        ID = 1,
                        Description = "occupied"
                    },
                    WallType = new KeyValue()
                    {
                        ID = 1,
                        Description = "its a wall"
                    },
                    RoofType = new KeyValue()
                    {
                        ID = 1,
                        Description = "its a roof"
                    }
                },
                PolicyHolder =
                {
                    Title = new KeyValue()
                    {
                        ID=1, Description = "reverend"
                    },
                    FirstName = "Bob", 
                    LastName = "Smith", 
                    DateOfBirth = new DateTime(1978, 03, 30), 
                    EmailAddress = "moo@moo.com", 
                    MobilePhone = "07890999888",
                    MaritalStatus = new KeyValue
                    {
                        ID = 1, Description = "Married"
                    },
                    Gender = new KeyValue
                    {
                        ID = 1,
                        Description = "unsure"
                    }

                },
                ContentsAccidentalDamageCoverRequired = false,
                BuildingsAccidentalDamageCoverRequired = true,
                BuildingsVoluntaryExcess = "50",
                ContentsVoluntaryExcess = "100",
                YearsBuildingHeld = "3",
                YearsContentsHeld = "4"
            };
           

            vm.HouseholdClaims.Add(new HouseholdClaim
            {
                ThisAddress = false,
                IncidentCause = new KeyValue
                {
                    ID = 13
                }
            });

            vm.HouseholdClaims.Add(new HouseholdClaim
            {
                ThisAddress = false,
                IncidentCause = new KeyValue
                {
                    ID = 13
                }
            });

            vm.ExperiencedSubsidence = false;

            var mainDoor = new Door
            {
                DoorType = new KeyValue {ID = 1, Description = "Main Door"},
                LockType = new KeyValue {ID = 1, Description = "Moo"}
            };
            vm.PropertyDetails.MainDoor = mainDoor;

            var otherDoor = new Door
            {
                DoorType = new KeyValue {ID = 1, Description = "Other Door"},
                LockType = new KeyValue {ID = 1, Description = "Moo2"}
            };
            vm.PropertyDetails.ExternalDoor = otherDoor;

            var patioDoor = new Door
            {
                DoorType = new KeyValue {ID = 1, Description = "Patio Door"},
                LockType = new KeyValue {ID = 1, Description = "Moo3"}
            };
            vm.PropertyDetails.SlidingDoor = patioDoor;
            vm.PropertyDetails.WindowLocks = true;
            vm.OwnershipStatus = new KeyValue {ID = 1, Description = "something"};

            vm.BurglarAlarm = new BurglarAlarm
            {
                AlarmFittedAndUsed = true,
                ProfessionallyFittedAndMaintained = new KeyValue {ID = 1, Description = "yes by somebody"}
            };
            vm.RiskAddress = new AddressDetails
            {
                HouseNumber = "5",
                Postcode = "PE6 8ER",
                AddressLine1 = "Lichfield Close",
                AddressLine2 = "Deeping St. James",
                AddressLine3 = "Peterborough",
                AddressLine4 = "Cambridgeshire",
                AddressLine5 = ""
            };
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