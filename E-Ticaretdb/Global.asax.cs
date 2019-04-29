using E_Ticaretdb.DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using E_Ticaretdb.App_Start;

namespace E_Ticaretdb
{
    public class MvcApplication:HttpApplication
    {
       void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RegisterGlobalFilters(GlobalFilters.Filters);
            //GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        void Session_Start(object sender, EventArgs e)
        {

            if (CookieHelper.ReadCookie(CookieNames.SepetCookie, System.Web.HttpContext.Current.Request) == null)
            {
                var sepetHelper= new SepetEkleHelper();

                Guid sepetno = Guid.NewGuid();
                CookieHelper.CreateCookie(CookieNames.SepetCookie, sepetno.ToString(), DateTime.Today.AddYears(1), System.Web.HttpContext.Current.Response);

                sepetHelper.Create(sepetno);
            }

        }
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }
    }
}
