using System;
using App1.Models.Household;

namespace App1.Models.ViewModel
{
    public class PropertyCover
    {
        public PropertyCover()
        {
            CoverType = new KeyValue();
            ContentsCover = new ContentsCover();
        }
        public DateTime CommencementDate { get; set; }
        public KeyValue CoverType { get; set; }
        public ContentsCover ContentsCover { get; set; }
    }
}