using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace App1.Models
{
    public class MyVirtualPathProvider : VirtualPathProvider
    {
        public override bool FileExists(string virtualPath)
        {
            var page = FindPage(virtualPath);
            if (page == null)
            {
                return base.FileExists(virtualPath);
            }
            else
            {
                return true;
            }
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            return null;

        }

        public override String GetFileHash(String virtualPath, IEnumerable virtualPathDependencies)
        {
            return Guid.NewGuid().ToString();

        }

        public override VirtualFile GetFile(string virtualPath)
        {
            var page = FindPage(virtualPath);
            if (page == null)
            {
                return base.GetFile(virtualPath);
            }
            else
            {
                return new MyVirtualFile(virtualPath, page.ViewData.ToArray());
            }
        }

        private Page FindPage(string virtualPath)
        {

            var page =
                (from p in CustomPages.Pages
                 where p.ViewName == virtualPath
                 select p).SingleOrDefault();

            return page;

        }
    }
}