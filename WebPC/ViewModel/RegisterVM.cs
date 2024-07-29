using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebPC.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Tên không được để trống.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống.")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage ="Tài khoản không được để trống.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [Compare("Password",ErrorMessage ="Mật khẩu nhập lại phải giống nhau")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage ="Vui lòng nhập đúng định dạng Email")]
        public string Email {  get; set; }

    }
}