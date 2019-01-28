using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities.ValueObjects
{
    public class RegisterVM
    {
        [DisplayName("Kullanıcı Adı"),
            Required(ErrorMessage = "{0}nızı Giriniz.")]
        public string Username { get; set; }

        [DisplayName("Şifre"),
            Required(ErrorMessage = "{0}nizi Giriniz.")]
        public string Password { get; set; }

        [DisplayName("E-mail"),
            Required(ErrorMessage = "{0}nizi Adresi Giriniz.")]
        public string Email { get; set; }

        [DisplayName("Ad"),
            Required(ErrorMessage = "{0}ınızı Giriniz.")]
        public string Name { get; set; }

        [DisplayName("Soyad"),
            Required(ErrorMessage = "{0}ınızı Giriniz.")]
        public string Surname { get; set; }

        [DisplayName("Şifre Tekrar"),
            Compare("Password", ErrorMessage = "{1} ile {0} Eşleşmiyor !")]
        public string RePassword { get; set; }
    }
}