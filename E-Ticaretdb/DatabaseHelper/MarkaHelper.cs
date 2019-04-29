using E_Ticaretdb.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace E_Ticaretdb.DatabaseHelper
{
    public class MarkaHelper
    {
        Entities2 _c = new Entities2();

        public List<Marka> List(Expression<Func<Marka,bool>> query)
        {
            return _c.Marka.Where(x => x.Durum == true).ToList();
        }
    }
}