using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalcomaniaTour.BusinessLayer.Abstract;
using YalcomaniaTour.BusinessLayer.Result;
using YalcomaniaTour.Common.Helpers;
using YalcomaniaTour.DAL.EntityFramework;
using YalcomaniaTour.Entities;
using YalcomaniaTour.Entities.Message;
using YalcomaniaTour.Entities.ValueObjects;

namespace YalcomaniaTour.BusinessLayer
{
    public class TourUserManager : ManagerBase<TourUser>
    {
        //Kullanıcı Kayıt İşlemi
        public BusinessLayerResult<TourUser> RegisterUser(RegisterViewModel data)
        {
            BusinessLayerResult<TourUser> res = new BusinessLayerResult<TourUser>();
            //Kullanıcı kayıt ediyoruz
            //Aktivasyon e-postası gönderiyoruz.

            //Kullanıcı var mı kontrol ediyorum
            TourUser user = Find(x => x.UserName == data.UserName || x.Email == data.Email);

            //Kullanıcı varsa
            if (user != null)
            {
                if (user.UserName == data.UserName)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı kayıtlı");
                }

                if (user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "E-posta adresi kayıtlı");
                }
            }
            else
            {
                //user yoksa kullanıcı ekliyoruz
                int dbResult = base.Insert(new TourUser()
                {
                    UserName = data.UserName,
                    Email = data.Email,
                    Password = data.Password,
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = false,
                    IsAdmin = false

                });

                //insert ettiğimiz kullanıcıyı elde ediyoruz ve aktivasyon mail'ini gönderiyoruz.
                if (dbResult > 0)
                {
                    res.Result = Find(x => x.Email == data.Email && x.UserName == data.UserName);

                    string siteUri = ConfigHelper.Get<string>("SiteRootUri");
                    string activateUri = $"{siteUri}/Home/UserActive/{res.Result.ActivateGuid}";
                    string body = $"Merhaba {res.Result.UserName};" +
                        $"<br><br> Hesabınızı aktifleştirmek için <a href='{activateUri}' target='_blank'>tıklayınız</a>";

                    MailHelper.SendMail(body, res.Result.Email, "MyBlog Hesap Aktifleştirme");

                }
            }

            return res;
        }

        public BusinessLayerResult<TourUser> GetUserById(int id)
        {
            BusinessLayerResult<TourUser> res = new BusinessLayerResult<TourUser>();
            res.Result = Find(x => x.UserId == id);

            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.UserNotFound, "Kullanıcı bulunamadı");
            }

            return res;
        }

        public BusinessLayerResult<TourUser> LoginUser(LoginViewModel data)
        {
            BusinessLayerResult<TourUser> res = new BusinessLayerResult<TourUser>();

            res.Result = Find(x => x.UserName == data.Username && x.Password == data.Password);

            if (res.Result != null)
            {
                //Kullanıcı bulunması durumu
                if (!res.Result.IsActive)
                {
                    res.AddError(ErrorMessageCode.UserIsNotActive, "Kullanıcı aktifleştirilmemiştir");
                    res.AddError(ErrorMessageCode.CheckYourEmail, "Lütfen e-posta adresinizi kontrol ediniz.");
                }

            }
            else
            {
                res.AddError(ErrorMessageCode.UsernameOrPassWrong, "Kullanıcı adı ve şifre uyuşmuyor.");
            }


            return res;
        }

        public BusinessLayerResult<TourUser> UpdateProfile(TourUser data)
        {
            //kullanıcının yeni yazdığı username ve email'i kullanan biri var mı bakıyoruz
            TourUser db_user = Find(x => x.UserId != data.UserId && (x.UserName == data.UserName || x.Email == data.Email));

            //geri döndüreceğim tipten nesnemi oluşturuyorum.
            BusinessLayerResult<TourUser> res = new BusinessLayerResult<TourUser>();

            //kullanıcı varsa ve id'si işlem yapan kişinin id'sine eşit değilse
            if (db_user != null && db_user.UserId != data.UserId)
            {
                if (db_user.UserName == data.UserName)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Seçtiğiniz " + data.UserName + " kullanıcı adı başka bir kullanıcı tarafından kullanılıyor, farklı bir kullanıcı adı seçiniz.");
                }
                if (db_user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "Seçtiğiniz " + data.Email + " E-posta adresi başka bir kullanıcı tarafından kullanılıyor, farklı bir e-posta adresi seçiniz.");
                }

                return res;
            }

            //bir hata yoksa
            // DB'den update edilecek kullanıcıyı alıyorum, işimi garantiye alıyorum.
            res.Result = Find(x => x.UserId == data.UserId);
            res.Result.Email = data.Email;
            res.Result.Name = data.Name;
            res.Result.Surname = data.Surname;
            res.Result.Password = data.Password;
            res.Result.UserName = data.UserName;

            //ProfileImageFileName dosyası gelmiş mi, kişi resmini de güncelliyor mu?
            if (string.IsNullOrEmpty(data.ProfileImageFileName) == false)
            {
                //ProfileImageFileName'ini de güncelliyoruz.
                res.Result.ProfileImageFileName = data.ProfileImageFileName;
            }

            //Update işlemini yapıyoruz, eğer update işlemi sıfır döndüyse birşeyler ters gitti demektir.
            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Profil Güncellenemedi.");
            }

            return res;
        }

        public BusinessLayerResult<TourUser> RemoveUserById(int id)
        {
            //geri döndüreceğim tipten nesnemi oluşturuyorum.
            BusinessLayerResult<TourUser> res = new BusinessLayerResult<TourUser>();

            TourUser user = Find(x => x.UserId == id);

            if (user != null)
            {
                if (Delete(user) == 0)
                {
                    res.AddError(ErrorMessageCode.UserCouldNotRemove, "Kullanıcı silinemedi.");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.UserCouldNotFind, "Kullanıcı Bulunamadı.");
            }

            return res;

        }

        public BusinessLayerResult<TourUser> ActivateUser(Guid activateId)
        {
            BusinessLayerResult<TourUser> res = new BusinessLayerResult<TourUser>();

            res.Result = Find(x => x.ActivateGuid == activateId);

            //kullanıcı varsa
            if (res.Result != null)
            {
                //kullanıcı aktif mi?
                if (res.Result.IsActive)
                {
                    res.AddError(ErrorMessageCode.UserAlreadyActive, "Kullanıcı zaten aktif edilmiştir.");
                    return res;
                }

                //kullanıcı aktif değilse
                res.Result.IsActive = true;
                Update(res.Result);
            }
            else
            {
                //Eğer böyle bir Id yoksa, birisi sistemimizi deniyor olabilir
                res.AddError(ErrorMessageCode.ActivateIdDoesNotExists, "Aktifleştirilecek kullanıcı bulunamadı.");
            }

            return res;
        }

        //Model hiding
        public new BusinessLayerResult<TourUser> Insert(TourUser data)
        {
            BusinessLayerResult<TourUser> res = new BusinessLayerResult<TourUser>();

            //Admin kullanıcı eklerken Username veya Email'i kullan biri var mı diye bakıyoruz 
            TourUser user = Find(x => x.UserName == data.UserName || x.Email == data.Email);

            //parametre olarak gelen bilgileri res.Result'a aktardım. 
            res.Result = data;

            //Kullanıcı varsa
            if (user != null)
            {
                if (user.UserName == data.UserName)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı kayıtlı");
                }

                if (user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "E-posta adresi kayıtlı");
                }
            }
            else
            {
                //parametre olarak gelen bilgilerde ActivateGuid ve Resim bilgileri yok, ekliyoruz. 
                res.Result.ProfileImageFileName = "user_boy.png";
                res.Result.ActivateGuid = Guid.NewGuid();

                //user yoksa kullanıcı ekliyoruz
                if (base.Insert(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.UserCouldNotInserted, "Kullanıcı Eklenemedi");
                }

            }

            return res;
        }

        //Model hiding
        public new BusinessLayerResult<TourUser> Update(TourUser data)
        {
            BusinessLayerResult<TourUser> res = new BusinessLayerResult<TourUser>();

            //Admin kullanıcı güncellerken Username veya Email'i kullan biri var mı diye bakıyoruz 
            TourUser db_user = Find(x => x.UserName == data.UserName || x.Email == data.Email);

            //parametre olarak gelen bilgileri res.Result'a aktardım. 
            res.Result = data;

            //kullanıcı varsa ve id'si işlem yapan kişinin id'sine eşit değilse
            if (db_user != null && db_user.UserId != data.UserId)
            {
                if (db_user.UserName == data.UserName)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Seçtiğiniz " + data.UserName + " kullanıcı adı başka bir kullanıcı tarafından kullanılıyor, farklı bir kullanıcı adı seçiniz.");
                }
                if (db_user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "Seçtiğiniz " + data.Email + " E-posta adresi başka bir kullanıcı tarafından kullanılıyor, farklı bir e-posta adresi seçiniz.");
                }

                return res;
            }

            //bir hata yoksa
            //Database'den update edilecek kullanıcıyı alıyorum
            res.Result = Find(x => x.UserId == data.UserId);

            res.Result.Email = data.Email;
            res.Result.Name = data.Name;
            res.Result.Surname = data.Surname;
            res.Result.Password = data.Password;
            res.Result.UserName = data.UserName;
            res.Result.IsActive = data.IsActive;
            res.Result.IsAdmin = data.IsAdmin;

            //ActivateGuid ve Resim alanları Admin tarafından güncellenmeyecek.

            //Update işlemini yapıyoruz, eğer update işlemi sıfır döndüyse birşeyler ters gitti demektir.
            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.UserCouldNotUpdated, "Kullanıcı Güncellenemedi.");
            }

            return res;
        }
    }
}
