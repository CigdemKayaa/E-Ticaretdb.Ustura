using E_Ticaretdb.DatabaseHelper;
using E_Ticaretdb.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace E_Ticaretdb.WebService
{
    /// <summary>
    /// Summary description for ProductService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductService : System.Web.Services.WebService
    {
        UrunHelper urunHelper;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public bool UrunEkle(string urunadı,decimal birimfiyat,int stok ,string açıklama,string seopath)
        {
            urunHelper = new UrunHelper();
            Urunler urunler = new Urunler();
            urunler.UrunAdı = urunadı;
            urunler.BirimFiyat = birimfiyat;
            urunler.Stok = stok;
            urunler.Açıklama = açıklama;
            urunler.SeoPath = seopath;
            urunHelper.Add(urunler);
            return true;
        }
        [WebMethod]
        public bool UrunAdGonder(int urunID,string urunAd)
        {
            urunHelper = new UrunHelper();
            urunHelper.İsimDegistir(urunID, urunAd);
                return true;


        }
        [WebMethod]
        public string İsimDondurme(string ad)
        {
            return ad.ToUpper();

        }

    }

}
