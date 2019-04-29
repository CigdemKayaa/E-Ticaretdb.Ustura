using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CookieHelper
{
  public static void CreateCookie(CookieNames ad, string deger,DateTime expiredDate, System.Web.HttpResponse response )
    {
        System.Web.HttpCookie cookie = new System.Web.HttpCookie(ad.ToString());
        cookie.Expires = expiredDate;
        cookie.Value = deger;
        response.Cookies.Add(cookie);

    }

    public static string ReadCookie(CookieNames ad, HttpRequest request)
    {
        if (request.Cookies[ad.ToString()]== null)
        {
            return null;
        }
        else
        {
            return request.Cookies[ad.ToString()].Value;
        }
    }

    public static void WriteCookie(CookieNames ad,HttpRequest request,string deger)
    {
        request.Cookies[ad.ToString()].Value = deger;

    }
}

public enum CookieNames
{
    SepetCookie
}