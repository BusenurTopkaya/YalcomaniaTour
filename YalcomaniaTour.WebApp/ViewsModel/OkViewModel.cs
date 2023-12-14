using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YalcomaniaTour.WebApp.ViewsModel
{
    public class OkViewModel:NotifyViewModelBase<string>
    {
        public OkViewModel()
        {
            Title = "İşlem Başarılı";
        }
    }
}