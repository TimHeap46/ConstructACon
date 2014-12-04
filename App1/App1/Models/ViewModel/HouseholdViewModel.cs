using System;
using System.Collections.Generic;
using App1.Models.Helper.App1.Models;
using App1.Models.Household;
using App1.Models.ViewModel;
using Microsoft.Owin.BuilderProperties;

namespace App1.Models
{
    public class HouseholdViewModel : ViewModelBase
    {
        public HouseholdViewModel()
        {
            CoverType = new KeyValue();
            PolicyHolder = new Person();
            PropertyDetails = new PropertyDetails();
            HouseholdClaims = new List<HouseholdClaim>();
            OwnershipStatus = new KeyValue();
            BurglarAlarm = new BurglarAlarm();
            RiskAddress = new AddressDetails();
            PostalAddress = new AddressDetails();
        } 

        public Person PolicyHolder { get; set; }
        public DateTime CommencementDate { get; set; }
        public KeyValue CoverType { get; set; }
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

        public List<HouseholdClaim> HouseholdClaims { get; set; }

        public bool ExperiencedSubsidence { get; set; }

        public KeyValue OwnershipStatus { get; set; }

        public BurglarAlarm BurglarAlarm { get; set; }

        public AddressDetails RiskAddress { get; set; }

        public AddressDetails PostalAddress { get; set; }       
    }
}