using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebPC.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Tài khoản không được để trống.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        public string Password { get; set; }
    }
}