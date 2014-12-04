using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App1.Models
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