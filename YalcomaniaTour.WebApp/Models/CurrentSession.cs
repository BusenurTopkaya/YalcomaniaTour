using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YalcomaniaTour.Entities;

namespace YalcomaniaTour.WebApp.Models
{
    public class CurrentSession
    {
        //OOP Encapsulation uyguladık
        public static TourUser User
        {
            get
            {
                return Get<TourUser>("login");
            }

        }

        //Session Helper
        public static void Set<T>(string key, T obj)
        {
            HttpContext.Current.Session[key] = obj;
        }

        public static T Get<T>(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                return (T)HttpContext.Current.Session[key];
            }

            //nesneyi bulamazsa null dönüyor
            return default(T);
        }

        public static void Remove(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session.Remove(key);
            }
        }

        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}