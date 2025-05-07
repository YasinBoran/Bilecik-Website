using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proje.Models
{
    public class kayit
    {
        [Required(ErrorMessage = "E-posta adresi gerekli.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-posta:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gerekli.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre:")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Şifre kontrolü gerekli.")]
        [DataType(DataType.Password)]
        [Compare("Sifre", ErrorMessage = "Şifreler eşleşmiyor.")]
        [Display(Name = "Şifre Tekrarı:")]
        public string SifreKontrol { get; set; }
    };
}