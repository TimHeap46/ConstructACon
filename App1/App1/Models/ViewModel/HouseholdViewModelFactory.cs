using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App1.Models.Household;

namespace App1.Models.ViewModel
{
    public static class HouseholdViewModelFactory
    {
        public static HouseholdViewModel GiveMeAStubbedViewModel()
        {
            var vm = new HouseholdViewModel
            {
                CommencementDate = new DateTime(2014, 12, 25),
                QuoteReference = "a639807c-db93-42ec-bfea-3d90fbc03571",
                BuildingsCoverAmount = 700000,
                ContentsCoverAmount = 66001,
                CoverType = new KeyValue(3, "BuildingsAndContents"),
                PropertyDetails =
                {
                    NumberOfBedrooms = 2,
                    YearBuilt = 2012,
                    IsListedBuilding = false,
                    ListedBuildingType = new KeyValue(2, "Who knows.. or cares"),
                    PropertyType = "House",
                    OccupancyStatus = new KeyValue(1, "occupied"),
                    WallType = new KeyValue(1, "its a wall"),
                    RoofType = new KeyValue(1, "its a roof")
                },
                PolicyHolder =
                {
                    Title = new KeyValue(1, "reverend"),
                    FirstName = "John",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1978, 03, 30),
                    EmailAddress = "moo@moo.com",
                    MobilePhone = "07890999888",
                    MaritalStatus = new KeyValue(1, "Married"),
                    Gender = new KeyValue(1, "unsure"),
                    Occupation = new KeyValue(1, "chicken chaser")
                },
                ContentsAccidentalDamageCoverRequired = false,
                BuildingsAccidentalDamageCoverRequired = true,
                BuildingsVoluntaryExcess = "50",
                ContentsVoluntaryExcess = "100",
                YearsBuildingHeld = "3",
                YearsContentsHeld = "4",
                PropertyCover = new PropertyCover()
                
            };

            vm.PropertyCover.ContentsCover.YearHeld.Description = "F";


            vm.HouseholdClaims.Add(new HouseholdClaim
            {
                ThisAddress = false,
                IncidentCause = new KeyValue(13, "")
            });

            vm.HouseholdClaims.Add(new HouseholdClaim
            {
                ThisAddress = false,
                IncidentCause = new KeyValue(13, "")
            });

            vm.ExperiencedSubsidence = false;

            var mainDoor = new Door
            {
                DoorType = new KeyValue(1, "Main Door"),
                LockType = new KeyValue(1, "Moo")
            };
            vm.PropertyDetails.MainDoor = mainDoor;

            var otherDoor = new Door
            {
                DoorType = new KeyValue(1, "Other Door"),
                LockType = new KeyValue(1, "Moo2")
            };
            vm.PropertyDetails.ExternalDoor = otherDoor;

            var patioDoor = new Door
            {
                DoorType = new KeyValue(1, "Patio Door"),
                LockType = new KeyValue(1, "Moo3")
            };
            vm.PropertyDetails.SlidingDoor = patioDoor;
            vm.PropertyDetails.WindowLocks = true;
            vm.OwnershipStatus = new KeyValue(1, "something");

            vm.BurglarAlarm = new BurglarAlarm
            {
                AlarmFittedAndUsed = true,
                ProfessionallyFittedAndMaintained = new KeyValue(1, "yes by somebody")
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
    }
}