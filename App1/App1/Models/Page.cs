using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App1.Models
{
    public class Page
    {
        public string PageId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ViewName { get; set; }
        public byte[] ViewData { get; set; }
    }
}