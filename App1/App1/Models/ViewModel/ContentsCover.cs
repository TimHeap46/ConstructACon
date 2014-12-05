using App1.Models.Household;

namespace App1.Models.ViewModel
{
    public class ContentsCover
    {
        public ContentsCover()
        {
            YearHeld = new KeyValue();
        }
        public KeyValue YearHeld { get; set; }
    }
}