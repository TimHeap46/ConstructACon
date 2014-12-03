using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using App1.Controllers;
using App1.Helpers;

namespace App1.Models
{
    public class HouseholdViewModel
    {
        public Person PolicyHolder { get; set; }
        public DateTime CommencementDate { get; set; }
        public CoverType CoverType { get; set; }
        public string QuoteReference { get; set; }
        public int BuildingsCoverAmount { get; set; }
        public int ContentsCoverAmount { get; set; }
        public PropertyDetails PropertyDetails { get; set; }

        public bool ContentsAccidentalDamageCoverRequired{get; set; }
        public bool BuildingsAccidentalDamageCoverRequired { get; set; }

        public string ContentsVoluntaryExcess { get; set; }
        public string BuildingsVoluntaryExcess { get; set; }

        public string YearsBuildingHeld { get; set; }
        public string YearsContentsHeld { get; set; }

        public HouseholdViewModel()
        {
            this.CoverType = new CoverType();
            this.PropertyDetails = new PropertyDetails();
            this.PolicyHolder = new Person();
        }

        public void ProcessMappings(string providerCode)
        {
            var myType = typeof(HouseholdViewModel);

            var fields = GetOverridenFields(providerCode);
            
            foreach (var field in fields)
            {
                
                var targetProperty = myType.GetProperty(field);
                
                var targetPropertyValue = targetProperty.GetValue(this).ToString();

                var providerOverride = GetProviderValue(providerCode, targetPropertyValue);

                targetProperty.SetValue(this, providerOverride);
            }
        }

        private IEnumerable<string> GetOverridenFields(string providerCode)
        {
            //TODO: Go off to Mongo
            var fields = new List<string> {"ContentsVoluntaryExcess", "BuildingsVoluntaryExcess","PropertyDetails.PropertyType"};

            return fields;
        }

        private string GetProviderValue(string providerCode, string id)
        {
            //TODO: Go off to Mongo
            return "TODO";
        }

        
    }
}