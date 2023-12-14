using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YalcomaniaTour.WebApp.ViewsModel
{
    public class NotifyViewModelBase<T>
    {
        public string Header { get; set; }
        public string Title { get; set; }
        public List<T> Items { get; set; }
        public bool IsRedireting { get; set; }
        public string RedirectingUrl { get; set; }
        public int RedirectingTimeout { get; set; }

        public NotifyViewModelBase()
        {
            Header = "Yönlendiriliyorsunuz";
            Title = "Geçersiz İşlem";
            IsRedireting = true;
            RedirectingUrl = "/Home/Index";
            RedirectingTimeout = 5000;
            Items = new List<T>();
        }
    }
}