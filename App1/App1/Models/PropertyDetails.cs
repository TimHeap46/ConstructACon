using System.Collections.Generic;

namespace App1.Models
{
    public class PropertyDetails
    {
        public PropertyDetails()
        {
            MainDoor = new Door();
            SlidingDoor = new Door();
            ExternalDoor = new Door();
        }

        public int NumberOfBedrooms { get; set; }
        public int YearBuilt { get; set; }
        public bool IsListedBuilding { get; set; }
        public KeyValue ListedBuildingType { get; set; }
        public string PropertyType { get; set; }
        public KeyValue OccupancyStatus { get; set; }
        public KeyValue WallType { get; set; }
        public KeyValue RoofType { get; set; }
        public Door MainDoor { get; set; }
        public Door SlidingDoor { get; set; }
        public Door ExternalDoor { get; set; }
        public bool WindowLocks { get; set; }

    }
}