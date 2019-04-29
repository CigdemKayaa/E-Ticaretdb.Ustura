using E_Ticaretdb.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace E_Ticaretdb.DatabaseHelper
{


    public class UrunHelper
    {
        Entities2 _c = new Entities2();
        public IQueryable<Urunler> List(Expression<Func<Urunler, bool>> query = null)
        {
            if (query != null)
            {
                return _c.Urunler.Where(query);
            }
            else
            {
                return _c.Urunler;

            }

        }
        public Urunler Get(Expression<Func<Urunler, bool>> query)
        {
            _c = new Entities2();
            return _c.Urunler.SingleOrDefault(query);
        }
        public List<EnÇokSatanUrunler> EÇSUrunler()
        {
            _c = new Entities2();
            return _c.EnÇokSatanUrunler.ToList();
        }
        public List<EnÇokZiyaretEdilenUrun> ZiyaretEdilenUruns()
        {
            _c = new Entities2();
            return _c.EnÇokZiyaretEdilenUrun.ToList();
        }
        public void Add(Urunler data)
        {
            _c = new Entities2();
            _c.Urunler.Add(data);
            _c.SaveChanges();
        }
        public void İsimDegistir(int UrunID, string UrunAd)
        {
            _c = new Entities2();
            var Urun = _c.Urunler.SingleOrDefault(x => x.UrunID == UrunID);
            if (Urun != null)
            {
                Urun.UrunAdı = UrunAd;
                _c.SaveChanges();
            }
        }
    }
}