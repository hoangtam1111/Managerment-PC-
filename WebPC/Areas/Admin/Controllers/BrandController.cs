using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPC.Models;
using WebPC.Filters;
namespace WebPC.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class BrandController : Controller
    {
        // GET: Admin/Brand
        public ActionResult Index()
        {
            DatabaseEntities db = new DatabaseEntities();
            List<Brand> brands = db.Brand.ToList();
            return View(brands);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Brand b)
        {
            DatabaseEntities db = new DatabaseEntities();
            if (b.BrandId != null)
            {
                db.Brand.Add(b);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Update(int? id)
        {
            DatabaseEntities db = new DatabaseEntities();
            Brand brand = db.Brand.Where(t => t.BrandId == id).FirstOrDefault();
            if (id != null || brand.BrandId == null)
            {
                return View(brand);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Update(Brand b)
        {
            DatabaseEntities db = new DatabaseEntities();
            Brand brand = db.Brand.Where(t => t.BrandId == b.BrandId).FirstOrDefault();
            brand.BrandName = b.BrandName;
            brand.BrandLogo = b.BrandLogo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            DatabaseEntities db = new DatabaseEntities();
            Brand brand = db.Brand.Where(t => t.BrandId == id).FirstOrDefault();
            if (id != null)
            {
                return View(brand);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(Brand b)
        {
            DatabaseEntities db = new DatabaseEntities();
            Brand brand = db.Brand.Where(t => t.BrandId == b.BrandId).FirstOrDefault();
            db.Brand.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}