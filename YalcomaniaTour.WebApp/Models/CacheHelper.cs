using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using YalcomaniaTour.BusinessLayer;
using YalcomaniaTour.Entities;

namespace YalcomaniaTour.WebApp.Models
{
    public class CacheHelper
    {
        //Cahce'den okuma yapan static bir metoda ihtiyacımız var, bu metot kategorileri liste olarak dönecek.
        public static List<Ticket> GetCategoriesFromCache()
        {
            //Cache'e bakıyoruz, "category-cache" anahtarındaki kategorileri alacağız.
            var result = WebCache.Get("category-cache");

            if (result == null)
            {
                TicketManager categoryManager = new TicketManager();
                result = categoryManager.List();

                //kategorileri çektikten sonra Cache'liyoruz, Cahce'e yazıyoruz.
                //minutesToCahce : DATA ne kadar süre Cahce de kalacak.
                //slidingExpiration: ötelesin, eğer Cahce'den okuma yaparsam, her çağırdığımda ötelesin, süreyi hep sıfırlasın, böylece hep 20 dk devam edecek.
                WebCache.Set("category-cache", result, 20, true);
            }

            return result;
        }

        //Category Cache'in adını her seferinde hatırlayamayabilirim derseniz
        public static void RemoveCategoriesFromCache()
        {
            Remove("category-cache");
        }

        //vereceğimiz key'e ait datayı Cache'den temizleyecek olan metot 
        public static void Remove(string key)
        {
            WebCache.Remove(key);
        }
    }
}
