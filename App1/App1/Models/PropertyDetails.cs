namespace App1.Models
{
    public class PropertyDetails
    {
        public int NumberOfBedrooms { get; set; }
        public int YearBuilt { get; set; }
        public bool IsListedBuilding { get; set; }
        public KeyValue ListedBuildingType { get; set; }
        public string PropertyType { get; set; }
        public KeyValue OccupancyStatus { get; set; }
        public KeyValue WallType { get; set; }
        public KeyValue RoofType { get; set; }
    }
}