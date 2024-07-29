using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebPC.Models;
using WebPC.ViewModel;
using WebPC.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace WebPC.Controllers
{
    public class HomeController : Controller
    {
        int i = 1;
        // GET: Home
        public ActionResult Index()
        {
            DatabaseEntities db = new DatabaseEntities();
            List<SanPham> sp = db.SanPham.ToList();
            return View(sp);
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult DangKi(RegisterVM rvm)
        {
            if(ModelState.IsValid)
            {
                var appDbContext=new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var pass = Crypto.HashPassword(rvm.Password);
                var user = new AppUser()
                {
                    Email = rvm.Email,
                    UserName = rvm.Username,
                    PasswordHash = pass,
                    Name=rvm.Name,
                    DiaChi=rvm.DiaChi
                };
                IdentityResult identityResult = userManager.Create(user);
                if(identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("New Error", "InvalidData");
            return RedirectToAction("Login");
        }
        public ActionResult DangNhap(LoginVM lvm)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(lvm.Username, lvm.Password);
            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index","Home", new {area="Admin"});
                }
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("myError", "Không đúng tài khoản hoặc mật khẩu");
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index");
        }
        public ActionResult Info(string name)
        {
                AppDbContext db = new AppDbContext();
                AppUser user = db.Users.Where(t => t.UserName == name).FirstOrDefault();
                return View(user);

        }
    }
}