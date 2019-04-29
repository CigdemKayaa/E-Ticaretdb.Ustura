using E_Ticaretdb.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Ticaretdb.DatabaseHelper
{
    public class UrungörüntülemeHelper
    {
        Entities2 _c = new Entities2();
        public void Add(UrunGörüntüleme urunGörüntüleme)
        {
            _c.UrunGörüntüleme.Add(urunGörüntüleme);
            _c.SaveChanges();
        }
    }
}