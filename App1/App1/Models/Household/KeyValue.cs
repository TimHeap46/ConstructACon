using System.Runtime.InteropServices;

namespace App1.Models.Household
{
    public class KeyValue
    {
        public KeyValue()
        {
            
        }
        public KeyValue(int id, string description)
        {
            this.ID = ID;
            this.Description = description;
        }
        public int ID { get; set; }
        public string Description { get; set; }
    }
}