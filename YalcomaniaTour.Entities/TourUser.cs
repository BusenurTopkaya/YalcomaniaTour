using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YalcomaniaTour.Entities
{
    [Table("TourUsers")]
    public class TourUser 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [DisplayName("İsim"),
           StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Name { get; set; }

        [DisplayName("Soyad"),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Surname { get; set; }        

        [DisplayName("Kullanıcı Adı"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string UserName { get; set; }

        [DisplayName("E-Posta"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Email { get; set; }

        [DisplayName("Şifre"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Password { get; set; }
        [DisplayName("Aktif"),]
        public bool IsActive { get; set; }

        [DisplayName("Yönetici"),]
        public bool IsAdmin { get; set; }

        [DisplayName("Department"),
            StringLength(25)]
        public string Departman { get; set; }

        [DisplayName("Profile Image")]
        public string ProfileImageFileName { get; set; }


        [Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
