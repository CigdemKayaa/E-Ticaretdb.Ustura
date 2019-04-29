using E_Ticaretdb.CommonHelper;
using E_Ticaretdb.DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaretdb.Controllers
{
    public class SepetController : Controller
    {
        // GET: Sepet
        SepetEkleHelper sepetekleHelper;
        public ActionResult Index()
        {
            sepetekleHelper = new SepetEkleHelper();

            Guid SepetNo = CookieHelper.ReadCookie(CookieNames.SepetCookie, WebHelper.GetRequest).ToGuid();
            var sepetdata = sepetekleHelper.Get(SepetNo);
            return View(sepetdata.SepetItems.ToList());           

           
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                sepetekleHelper = new SepetEkleHelper();
                sepetekleHelper.Remove((int)id);

                Guid sepetno = CookieHelper.ReadCookie(CookieNames.SepetCookie, WebHelper.GetRequest).ToGuid();

                var itemControl = sepetekleHelper.GetItems(sepetno);
                if (itemControl.Count != 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }


            return View();

        }
    }
}