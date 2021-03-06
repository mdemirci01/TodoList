﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "E-Posta Adresi Zorunludur")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required(ErrorMessage = "Sağlayıcı Gereklidir")]
        public string Provider { get; set; }

        [Required(ErrorMessage = "Size Gelen Kodu Giriniz")]
        [Display(Name = "Kod")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Bu tarayıcıyı hatırlıyor musun?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [EmailAddress(ErrorMessage = "Geçersiz E-Posta Adresi")]
        [Required (ErrorMessage = "E-Posta Adresi Zorunludur")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {

        [Required(ErrorMessage = "E-Posta Alanı Zorunludur")]
        [Display(Name = "E-Posta")]
        [EmailAddress(ErrorMessage ="Geçersiz E-Posta Adresi")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Zorunludur")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "E-Posta Alanı Zorunludur")]
        [EmailAddress(ErrorMessage ="Geçersiz E-Posta Adresi")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Zorunludur")]
        [StringLength(100, ErrorMessage = "{0} en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Onayla")]
        [Compare("Password", ErrorMessage = "Parola ve doğrulama parolası uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "E-Posta Alanı Zorunludur")]
        [EmailAddress(ErrorMessage = "Geçersiz E-Posta Adresi")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Zorunludur")]
        [StringLength(100, ErrorMessage = "{0} en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifreni Onayla")]
        [Compare("Password", ErrorMessage = "Parola ve doğrulama parolası uyuşmuyor..")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "E-Posta Alanı Zorunludur")]
        [EmailAddress(ErrorMessage = "Geçersiz E-Posta Adresi")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
    }
}
