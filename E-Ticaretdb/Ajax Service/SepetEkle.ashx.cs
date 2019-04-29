using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Ticaretdb.CommonHelper;
using E_Ticaretdb.DatabaseHelper;
using E_Ticaretdb.DatabaseModel;
using E_Ticaretdb.Models;


namespace E_Ticaretdb.Ajax_Service
{
    /// <summary>
    /// Summary description for SepetEkle
    /// </summary>
    public class SepetEkle : IHttpHandler
    {
        SepetEkleHelper sepetEkleHelper;
        public void ProcessRequest(HttpContext context)
        {
            sepetEkleHelper = new SepetEkleHelper();

            int UrunID =Convert.ToInt32( context.Request["UrunID"]);
            int Miktar= Convert.ToInt32(context.Request["Miktar"]);
            Guid SepetNo = CookieHelper.ReadCookie(CookieNames.SepetCookie, WebHelper.GetRequest).ToGuid();
            var sepetData = sepetEkleHelper.Get(SepetNo);
            sepetData.SepetItems.ToList();
            SepetItems sepetItems = new SepetItems();
            sepetItems.SepetID = sepetData.SepetID;
            sepetItems.UrunID = UrunID;
            sepetItems.Miktar = Miktar;
            sepetItems.BirimFiyat = new UrunHelper().Get(x => x.UrunID == UrunID).BirimFiyat.Value;

            sepetEkleHelper.AddProduct(SepetNo, sepetItems);

            SepetJsonBasicModel json = new SepetJsonBasicModel();
            var mevcutSepet = sepetEkleHelper.Get(SepetNo);
            json.Miktar =(int) mevcutSepet.SepetItems.Sum(x => x.Miktar);
            json.Toplam = (int)mevcutSepet.SepetItems.Sum(x => x.BirimFiyat * x.Miktar);

            string jsonResult = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(json);

            context.Response.ContentType = "text/plain";
            //tüm verileri text e çevirmek için 

            context.Response.Write(jsonResult);


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}