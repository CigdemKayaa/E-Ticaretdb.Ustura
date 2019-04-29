using E_Ticaretdb.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaretdb.DatabaseHelper
{
   public interface ISepetEkle
    {
        void Create(Guid sepetKey);
        void AddProduct(Guid sepetKey, SepetItems sepetItems);
        void RemoveProduct(Guid sepetKey, int UrunID);

       Sepet Get(Guid sepetKey);
        List<SepetItems> GetItems(Guid sepetKey);
        List<SepetItems> GetItems(Expression<Func<SepetItems, bool>> query);
    }
}
