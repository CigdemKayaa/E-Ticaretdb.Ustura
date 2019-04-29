using E_Ticaretdb.DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaretdb.Controllers
{
    public class SharedController : Controller
    {
        SepetEkleHelper sepetEkleHelper;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MasterLayout()
        {
            return View();
        }
    }
}