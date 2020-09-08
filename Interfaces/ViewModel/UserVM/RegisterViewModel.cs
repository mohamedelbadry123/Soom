using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Interfaces.ViewModel.UserVM
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "يرجى ادخال البريد الألكترونى !")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "يرجى ادخال الأسم !")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "يرجى اضافه رقم سرى اقوى من الحالى !", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "الرقم السرى غير متطابق !")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "اختر الصلاحية !")]
        public string Role { get; set; }

        public string Error { get; set; }
    }
}
