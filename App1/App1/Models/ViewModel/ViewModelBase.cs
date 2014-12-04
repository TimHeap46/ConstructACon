using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App1.Models.Helper.App1.Models;

namespace App1.Models.ViewModel
{
    public class ViewModelBase
    {
        public void ProcessOverrides(string providerCode)
        {
            var fields = GetOverridenFields(providerCode);

            foreach (var field in fields)
            {
                var riskValue = this.GetPropValue(field);

                var providerOverride = GetProviderValue(providerCode, field, riskValue.ToString());

                ReflectionHelper.SetProperty(this, field, providerOverride);
            }
        }

        private IEnumerable<string> GetOverridenFields(string providerCode)
        {
            //TODO: Go off to Mongo
            var fields = new List<string> 
            {
                "ContentsVoluntaryExcess", 
                "BuildingsVoluntaryExcess",
                "PropertyDetails.PropertyType",
                "PropertyDetails.OccupancyStatus.Description",
                "PropertyDetails.WallType.Description",
                "PropertyDetails.RoofType.Description",
                "PropertyDetails.MainDoor.LockType.Description",
                "PropertyDetails.ExternalDoor.LockType.Description",
                "PropertyDetails.SlidingDoor.LockType.Description",
                "OwnershipStatus.Description",
                "PolicyHolder.Title.Description",
                "PolicyHolder.Gender.Description"
            };

            return fields;
        }

        private string GetProviderValue(string providerCode, string overrideTable, string riskValue)
        {
            //TODO: Go off to Mongo
            return string.Format("{0} - TODO", overrideTable);
        }
    }
}