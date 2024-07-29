using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPC.Identity;
using WebPC.Filters;
using System.IO;
using WebPC.Models;

namespace WebPC.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UsersController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            AppDbContext db = new AppDbContext();
            List<AppUser> users = db.Users.ToList();
            return View(users);
        }
        public ActionResult Detail(string id)
        {
            AppDbContext db = new AppDbContext();
            AppUser user = db.Users.Where(t => t.UserName == id).FirstOrDefault();
            return View(user);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(AppUser user)
        {
            AppDbContext db = new AppDbContext();
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string username)
        {
            AppDbContext db = new AppDbContext();
            AppUser user = db.Users.Where(t => t.UserName == username).FirstOrDefault();
            if (user.UserName!=null)
            {
                return View(user);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(AppUser u)
        {
            AppDbContext db = new AppDbContext();
            AppUser user = db.Users.Where(t => t.UserName == u.UserName).FirstOrDefault();
            user.Name = u.Name;
            user.Email = u.Email;
            user.DiaChi = u.DiaChi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string name)
        {
            AppDbContext db = new AppDbContext();
            AppUser user = db.Users.Where(t => t.UserName == name).FirstOrDefault();
            if (user.UserName != null)
            {
                return View(user);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(AppUser u)
        {
            AppDbContext db = new AppDbContext();
            AppUser user = db.Users.Where(t => t.UserName == u.Name).FirstOrDefault();
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}