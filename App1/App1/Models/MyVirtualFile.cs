using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace App1.Models
{
    public class MyVirtualFile : VirtualFile
    {
        private byte[] data;

        public MyVirtualFile(string virtualPath, byte[] data)
            : base(virtualPath)
        {
            this.data = data;
        }

        public override System.IO.Stream Open()
        {
            return new MemoryStream(data);
        }
    }
}