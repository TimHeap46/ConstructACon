namespace App1.Models.Household
{
    public class HouseholdClaim
    {
        
            public KeyValue IncidentType { get; set; }
            public KeyValue IncidentCause { get; set; }
            public bool AnyDamage { get; set; }
            public int IncidentValue { get; set; }
            public bool ThisAddress { get; set; }
        
    }
}