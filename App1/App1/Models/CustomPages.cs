using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App1.Models
{
    public static class CustomPages
    {
        private static List<Page> pages;

        public static List<Page> Pages
        {
            get
            {
                pages = new List<Page>();
                var p1 = new Page{PageId = "1",Title = "Title",Body = "Body",ViewName = "~/Pages/Display/ViewName1",ViewData = new byte[12]};

                pages.Add(p1);

                return pages;
            }
        }
    }
}