using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalcomaniaTour.Entities;

namespace YalcomaniaTour.DAL.EntityFramework
{
   class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            TourUser admin = new TourUser()
            {
                Name = "Busenur",
                Surname = "Topkaya",
                Email = "busenur998@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                UserName = "Bsnr",
                Password = "123456",
                ProfileImageFileName = "gorsel.jpg"
            };

            TourUser standartUser = new TourUser()
            {
                Name = "Can",
                Surname = "Şen",
                Email = "cansen@abc.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                UserName = "cansen",
                Password = "123123",
                IsAdmin = false,
                ProfileImageFileName = "gorsel.jpg"
            };

            context.TourUsers.Add(admin);
            context.TourUsers.Add(standartUser);


            context.SaveChanges();

            List<TourUser> userlist = context.TourUsers.ToList();
                     
        }
    }
}
