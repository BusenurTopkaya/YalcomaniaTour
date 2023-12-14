using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YalcomaniaTour.BusinessLayer;
using YalcomaniaTour.BusinessLayer.Result;
using YalcomaniaTour.Entities;
using YalcomaniaTour.Entities.ValueObjects;
using YalcomaniaTour.WebApp.Models;
using YalcomaniaTour.WebApp.ViewsModel;

namespace YalcomaniaTour.WebApp.Controllers
{
    public class HomeController : Controller
    {
        TourUserManager tum = new TourUserManager();
        
        public ActionResult Index()
        {
            //HotelManager hotelManager = new HotelManager();
            //hotelManager.GetHotelList();
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //Business - Giriş kontrolü 
            //Business - Hesap aktive edilmiş mi?
            //Session'a kullanıcı bilgi saklama..
            //yönlendirme..

            if (ModelState.IsValid)
            {
                BusinessLayerResult<TourUser> result = tum.LoginUser(model);

                if (result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    return View(model);
                }

                CurrentSession.Set<TourUser>("login", result.Result);

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index");

            }


            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                BusinessLayerResult<TourUser> result = tum.RegisterUser(model);

                if (result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }


                OkViewModel notifjObj = new OkViewModel()
                {
                    Title = "Kayıt Başarılı",
                    RedirectingUrl = "/Home/Index"
                };
                notifjObj.Items.Add("lütfen e-posta adresinize gönderdiğimiz aktivasyon link'ine tıklayarak hesabınızı aktive ediniz. Hesabınızı aktiv etmeden not eklemeyemez ve beğenme yapamazsınız.");

                return View("Ok", notifjObj);
            }

            return View(model);
        }
        public ActionResult UserActive(Guid id)
        {
            BusinessLayerResult<TourUser> result = tum.ActivateUser(id);

            if (result.Errors.Count > 0)
            {
                ErrorViewModel notifjObj = new ErrorViewModel()
                {
                    Title = "Geçersiz İşlem",
                    Items = result.Errors
                };

                return View("Error", notifjObj);
            }

            OkViewModel okNotifjObj = new OkViewModel()
            {
                Title = "Hesabınız aktifleştirildi.",
                RedirectingUrl = "/Home/Login"
            };
            okNotifjObj.Items.Add("Hesabınız Aktifleştirildi. Artık not paylaşabilir ve beğenme yapabilirsiniz.");

            return View("Ok", okNotifjObj);
        }

        public ActionResult About()
        {
            return View();
        }

      
        public ActionResult RegisterOk()
        {
            return View();
        }

        public ActionResult Logout()
        {
            //formsauthentication.signout();

            // İsteğe bağlı olarak başka bir sayfaya yönlendirme yapabilirsiniz.
            return RedirectToAction("Index", "Home");
          
        }

        public ActionResult SalesOffice()
        {
            return View();
        }



    }
}