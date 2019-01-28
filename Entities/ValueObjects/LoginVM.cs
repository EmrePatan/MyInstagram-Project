using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities.ValueObjects
{
    public class LoginVM
    {
        [DisplayName("Kullanıcı Adı veya E-mail Adresi"),
            Required(ErrorMessage ="Lütfen {0}'nizi Giriniz.")]
        public string Identity { get; set; }

        [DisplayName("Şifre"),
            Required(ErrorMessage = "Lütfen {0}'nizi Giriniz.")]
        public string Password { get; set; }
    }
}