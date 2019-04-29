using E_Ticaretdb.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace E_Ticaretdb.DatabaseHelper
{
    public class SlaytHelper
    {
        Entities2 _c = new Entities2();

        public Slayt Get(Expression<Func<Slayt,bool>> query)
        {
            return _c.Slayt.FirstOrDefault(query);


        }
    }
}