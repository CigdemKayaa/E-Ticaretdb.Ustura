using E_Ticaretdb.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace E_Ticaretdb.DatabaseHelper
{
    public class WebSiteBlogHelper
    {
        Entities2 _c = new Entities2();

        public WebSiteBlog Get(Expression<Func<WebSiteBlog,bool>>query)
        {
            return _c.WebSiteBlog.SingleOrDefault(query);

        }
    }
}