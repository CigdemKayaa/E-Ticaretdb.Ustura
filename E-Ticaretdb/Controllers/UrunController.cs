using E_Ticaretdb.DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaretdb.Controllers
{
    public class UrunController : Controller
    {
        // GET: Product
        UrunHelper urunHelper;
        UrungörüntülemeHelper urungörüntülemeHelper;
        public ActionResult Index(string urunseolupath)
        {
            urunHelper = new UrunHelper();
            var urun = urunHelper.Get(x => x.SeoPath ==urunseolupath);
            return View(urun);
        }
        [HttpPost]
        public ActionResult Index(string seopath,int urunID,string ad,string email,string goruntuleme)
        {
            urungörüntülemeHelper = new UrungörüntülemeHelper();

            urungörüntülemeHelper.Add(new DatabaseModel.UrunGörüntüleme() {Ad=ad,GörüntülemeTarihi=DateTime.Now,UrunID=urunID,Görüntüleme=goruntuleme});
            Response.Redirect("/urundetay/" + seopath);
            urunHelper = new UrunHelper();
            var urun = urunHelper.Get(x => x.SeoPath == seopath);

            return View(urun);

        }
    }
}