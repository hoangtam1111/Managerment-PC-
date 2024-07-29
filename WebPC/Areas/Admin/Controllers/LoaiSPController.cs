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
    public class LoaiSPController : Controller
    {
        // GET: Admin/LoaiSP
        public ActionResult Index()
        {
            DatabaseEntities db = new DatabaseEntities();
            List<LoaiSP> loaiSPs = db.LoaiSP.ToList();
            return View(loaiSPs);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(LoaiSP l)
        {
            DatabaseEntities db = new DatabaseEntities();
            if (l.MaLoai != null)
            {
                db.LoaiSP.Add(l);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Update(int? id)
        {
            DatabaseEntities db = new DatabaseEntities();
            LoaiSP loaiSP = db.LoaiSP.Where(t => t.MaLoai == id).FirstOrDefault();
            if (id != null || loaiSP.MaLoai == null)
            {
                return View(loaiSP);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Update(LoaiSP l)
        {
            DatabaseEntities db = new DatabaseEntities();
            LoaiSP loaiSP = db.LoaiSP.Where(t => t.MaLoai == l.MaLoai).FirstOrDefault();
            loaiSP.TenLoai = l.TenLoai;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            DatabaseEntities db = new DatabaseEntities();
            LoaiSP loaiSP = db.LoaiSP.Where(t => t.MaLoai == id).FirstOrDefault();
            if (id != null)
            {
                return View(loaiSP);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(LoaiSP l)
        {
            DatabaseEntities db = new DatabaseEntities();
            LoaiSP loaiSP = db.LoaiSP.Where(t => t.MaLoai == l.MaLoai).FirstOrDefault();
            db.LoaiSP.Remove(loaiSP);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}