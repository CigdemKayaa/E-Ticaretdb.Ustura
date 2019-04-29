using E_Ticaretdb.CommonHelper;
using E_Ticaretdb.DatabaseHelper;
using E_Ticaretdb.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaretdb.Controllers
{
    public class PartialController : Controller
    {
        KategoriHelper kategoriHelper;
        SlaytHelper slaythelper;
        UrunHelper urunHelper;
        // GET: Partial
        public ActionResult Index()
        {
            return View();       
        }
        public ActionResult HeaderAreaPartial()
        {
            return View();
        }
        public ActionResult SiteBrandsAreaPartial()
        {
            Guid Sepetno = CookieHelper.ReadCookie(CookieNames.SepetCookie, WebHelper.GetRequest).ToGuid();

            var currentBasket = new SepetEkleHelper().Get(Sepetno);
            ViewBag.Miktar = currentBasket.SepetItems.Sum(x => x.Miktar);
            ViewBag.ToplamFiyat = currentBasket.SepetItems.Sum(x => x.BirimFiyat * x.Miktar);

            return View();
        }
        public ActionResult MainMenuAreaPartial()
        {


            kategoriHelper = new KategoriHelper();
            var list = kategoriHelper.List(x => x.Durum == true);
            return View(list);
        }
        public ActionResult FooterPartial()
        {
            //var webSiteBlogHelper = new E_Ticaretdb.DatabaseHelper.WebSiteBlogHelper();
            //string html = webSiteBlogHelper.Get(x => x.BlogAdı == "footer").BlogHtml;
            //ViewBag.Html = html;
            return View();
        }
        public ActionResult SliderAreaPartial()
        {
          slaythelper = new SlaytHelper();
            var aktifslayt = slaythelper.Get(x => x.BaşlamaTarih < DateTime.Now && x.BitişTarih > DateTime.Now && x.Durum== true);

            return View(aktifslayt.SlaytItems.ToList());
        }
        public ActionResult PromoAreaPartial()
        {
            return View();
        }
        public ActionResult MainContentAreaPartial()
        {
            urunHelper = new UrunHelper();
            if (System.Web.HttpContext.Current.Cache["MainContentAreaPartial"] == null)
            {
                var cacheData = urunHelper.List(x => x.Stok> 0).Take(20).ToList();
                System.Web.HttpContext.Current.Cache["MainContentAreaPartial"] = cacheData;
                return View(cacheData);
            }
            else
            {
                var cacheData = System.Web.HttpContext.Current.Cache["MainContentAreaPartial"];
                return View((List<Urunler>)System.Web.HttpContext.Current.Cache["MainContentAreaPartial"]);
            }
        }
        public ActionResult BrandsAreaPartial()
        {
            return View(new E_Ticaretdb.DatabaseHelper.MarkaHelper().List(x => x.Durum == true));
        }
        public ActionResult ProductWidgetAreaPartial()
        {
            E_Ticaretdb.Models.ProductWidgetAreaModel productWidgetAreaModel = new Models.ProductWidgetAreaModel();
            urunHelper= new UrunHelper();
            var date = DateTime.Now.AddDays(-140);
            productWidgetAreaModel.TopNew = urunHelper.List(x => x.EklenmeTARİHİ >= date).ToList();
            productWidgetAreaModel.TopProducts = urunHelper.EÇSUrunler();
            productWidgetAreaModel.TopVisitProduct = urunHelper.ZiyaretEdilenUruns();

            return View(productWidgetAreaModel);
        }
        
    }
}