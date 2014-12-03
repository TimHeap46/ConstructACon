using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App1.Models;

namespace App1.Controllers
{
    public class PagesController : Controller
    {
        public ActionResult Display(string id)
        {
            var res =
                (from p in CustomPages.Pages
                 where p.PageId == id
                 select p).SingleOrDefault();

            if (res == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["Title"] = res.Title;
            ViewData["Body"] = res.Body;

            return View(System.IO.Path.GetFileNameWithoutExtension(res.ViewName));
        }
    }
}