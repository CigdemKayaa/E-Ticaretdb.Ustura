
using E_Ticaretdb.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace E_Ticaretdb.DatabaseHelper
{
    public class KategoriHelper
    {

        Entities2 _c = new Entities2();

        public List<Kategori> List(Expression<Func<Kategori, bool>> query)
        {
            return _c.Kategori.Where(query).ToList();

        }
    }
}