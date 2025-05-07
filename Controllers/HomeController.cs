using Proje.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Proje.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult dilDegistir(string lang, string returnUrl)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

                // Oturuma dil bilgisini kaydet
                Session["Dil"] = new CultureInfo(lang);

                // Çerez oluştur ve dil bilgisini sakla
                HttpCookie cookie = new HttpCookie("language", lang)
                {
                    Expires = DateTime.Now.AddDays(7) // Çerezin 7 gün geçerli olması için
                };
                Response.Cookies.Add(cookie);
            }

            // Eğer returnUrl boşsa, varsayılan bir sayfaya yönlendir
            return Redirect(returnUrl ?? Url.Action("Index", "Home"));
        }
        protected void Application_AcquireRequestState(Object o, EventArgs a)
        {
            if (Session == null) return;

            CultureInfo dil = (CultureInfo)Session["Dil"];

            if (dil == null)
            {
                // Çerezden dil bilgisini al
                HttpCookie cookie = Request.Cookies["language"];
                string languageName = cookie != null ? cookie.Value : "tr";

                dil = new CultureInfo(languageName);
                Session["Dil"] = dil;
            }

            // Dil bilgisini iş parçacığına uygula
            Thread.CurrentThread.CurrentUICulture = dil;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(dil.Name);
        }
    }
}