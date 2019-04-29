using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using E_Ticaretdb.DatabaseHelper;
using E_Ticaretdb.DatabaseModel;

namespace E_Ticaretdb.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UrunWCFServis" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UrunWCFServis.svc or UrunWCFServis.svc.cs at the Solution Explorer and start debugging.
    public class UrunWCFServis : IUrunWCFServis
    {
        public void DoWork()
        {
        }

        public List<UrunModel> List()
        {
            UrunHelper urunHelper = new UrunHelper();
            var urun = urunHelper.List().ToList();
            List<UrunModel> model = new List<UrunModel>();
            foreach (var item in urun)
            {
                model.Add(new UrunModel() { UrunAd = item.UrunAdı, Stok = (int)item.Stok, BirimFiyat = (decimal)item.BirimFiyat });
                
            }
            return model;

        }

        List<Urunler> IUrunWCFServis.List()
        {
            throw new NotImplementedException();
        }
        public class UrunModel
            {
            [DataMember]
            public string UrunAd { get; set; }
            [DataMember]
            public decimal BirimFiyat { get; set; }
            [DataMember]
            public int Stok { get; set; }
        }

    }
}
