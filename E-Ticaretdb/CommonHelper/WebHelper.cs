using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Ticaretdb.CommonHelper
{
    public class WebHelper
    {
        public static HttpRequest GetRequest
        {
            get { return System.Web.HttpContext.Current.Request; }

        }
        public static HttpResponse GetResponse
        {
            get { return System.Web.HttpContext.Current.Response; }

        }
    }
}