using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using E_Ticaretdb.DatabaseModel;

namespace E_Ticaretdb.DatabaseHelper
{
   
    public class SepetEkleHelper : ISepetEkle
    {
        Entities2 _c = new Entities2();

        public void AddProduct(Guid sepetKey, SepetItems sepetItems)
        {
            var sepet = _c.Sepet.SingleOrDefault(x => x.SepetNo == sepetKey);
            if (sepet != null)
            {
                var seciliurun = sepet.SepetItems.FirstOrDefault(x => x.UrunID == sepetItems.UrunID);
                if (seciliurun!=null)
                {
                    seciliurun.Miktar += sepetItems.Miktar;

                }
                else
                {
                    _c.SepetItems.Add(sepetItems);


                }
                _c.SaveChanges();
            }
        }

        public void Create(Guid sepetKey)
        {
            _c = new Entities2();
            _c.Sepet.Add(new Sepet() { SepetNo = sepetKey, SiparisTarihi = DateTime.Now });
            _c.SaveChanges();
        }

        public Sepet Get(Guid sepetKey)
        {
            _c = new Entities2();
            var sepet = _c.Sepet.SingleOrDefault(x => x.SepetNo == sepetKey);
            return sepet;
        }

        public List<SepetItems> GetItems(Guid sepetKey)
        {
            _c =new Entities2();
            var sepetItems = _c.SepetItems.Where(x => x.Sepet.SepetNo == sepetKey).ToList();
            return sepetItems;
        }

        public List<SepetItems> GetItems(Expression<Func<SepetItems, bool>> query)
        {
            _c = new Entities2();
            var sepetItems = _c.SepetItems.Where(query).ToList();
            return sepetItems;
        }

        public void RemoveProduct(Guid sepetKey, int UrunID)
        {
            _c = new Entities2();
            int SepetID = _c.Sepet.SingleOrDefault(x => x.SepetNo == sepetKey).SepetID;
            var removedItems = _c.SepetItems.SingleOrDefault(x => x.SepetID == SepetID && x.UrunID == UrunID);
            if (removedItems!=null)
            {
                _c.SepetItems.Remove(removedItems);
                _c.SaveChanges();

            }
        }
        public void Remove(int sepetItemsID)
        {
            _c = new Entities2();
           
            var SepetItem = _c.SepetItems.SingleOrDefault(x =>x.SepetItemsID==sepetItemsID);
            if (SepetItem != null)
            {
                _c.SepetItems.Remove(SepetItem);
                _c.SaveChanges();

            }
        }
    }
}