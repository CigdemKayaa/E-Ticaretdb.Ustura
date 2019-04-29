using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Ticaretdb.CommonHelper
{
    public static class ExtentionMethods
    {
        public static int ToInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }
        public static Guid ToGuid(this string str)
        {
            return Guid.Parse(str);
        }
    }
}