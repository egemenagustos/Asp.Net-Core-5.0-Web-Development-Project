﻿using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı girin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı girin")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Resim URL girin")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage ="Lütfen kullanıcı adını girin")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi girin")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar girin")]
        [Compare("Password",ErrorMessage ="Şifreler uyumlu değil")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen mail girin")]
        public string Mail { get; set; }

    }
}
