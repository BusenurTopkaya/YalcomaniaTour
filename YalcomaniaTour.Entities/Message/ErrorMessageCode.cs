using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YalcomaniaTour.Entities.Message
{
    public enum ErrorMessageCode
    {
        UsernameAlreadyExists = 101,    //Kullanıcı adı var
        EmailAlreadyExists = 102,       //E-posta var
        UserIsNotActive = 201,          //Kullanıcı aktifleştirilmemiş
        UsernameOrPassWrong = 202,      //Kullanıcı adı veya şifre uyuşmuyor
        CheckYourEmail = 203,            //Email'inizi kontrol ediniz.
        UserNotFound = 204,
        UserCouldNotRemove = 205,
        UserCouldNotFind = 206,
        UserAlreadyActive = 207,
        UserCouldNotUpdated = 208,
        UserCouldNotInserted = 209,
        ProfileCouldNotUpdated = 210,
        ActivateIdDoesNotExists = 211
    }
}
