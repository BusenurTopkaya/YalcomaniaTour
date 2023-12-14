using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YalcomaniaTour.Common;
using YalcomaniaTour.Entities;
using YalcomaniaTour.WebApp.Models;

namespace YalcomaniaTour.WebApp.Initialize
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            TourUser user = CurrentSession.User;
            if (user != null)
                return user.Name;
            else
                return "system";
        }
    }
}