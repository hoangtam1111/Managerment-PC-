using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPC.Models;
using WebPC.Filters;

namespace WebPC.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string search = "", string nameSort = "", int page = 1, int loaiSP = 0, int brand = 0)
        {
            DatabaseEntities db = new DatabaseEntities();
            // search
            List<SanPham> sp = db.SanPham.Where(t => t.TenSP.Contains(search)).ToList();
            ViewBag.Search = search;
            if (loaiSP != 0)
            {
                sp = sp.Where(t => t.MaLoai == loaiSP).ToList();
            }
            ViewBag.LoaiSP = loaiSP;
            if (brand != 0)
            {
                sp = sp.Where(t => t.BrandId == brand).ToList();
            }
            ViewBag.Brand = brand;
            //sort
            if (nameSort == "TenSP")
                sp = sp.OrderBy(t => t.TenSP).ToList();
            else if (nameSort == "GiaTang")
                sp = sp.OrderBy(t => t.Gia).ToList();
            else if (nameSort == "GiaGiam")
                sp = sp.OrderByDescending(t => t.Gia).ToList();
            else if (nameSort == "Loai")
                sp = sp.OrderBy(t => t.MaLoai).ToList();
            else if (nameSort == "Brand")
                sp = sp.OrderBy(t => t.BrandId).ToList();
            ViewBag.NameSort = nameSort;

            //Page
            int n = 20;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(n)));
            int NoOfRecordToSkip = (page - 1) * n;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sp = sp.Skip(NoOfRecordToSkip).Take(n).ToList();
            return View(sp);
        }
        public ActionResult Detail(int? id)
        {
            ViewBag.Id = id;
            return View();
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(SanPham sp, HttpPostedFileBase Anh)
        {
            if (Anh != null || Anh.ContentLength > 0)
            {
                string fileName = Path.GetFileName(Anh.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Images/product/"), fileName);
                Anh.SaveAs(path);
            }
            sp.Anh = Anh.FileName.ToString();
            DatabaseEntities db = new DatabaseEntities();
            db.SanPham.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        public ActionResult Edit(int? id)
        {
            DatabaseEntities db = new DatabaseEntities();
            List<SanPham> sp = db.SanPham.ToList();
            if (id != null && sp.Any(t => t.MaSP == id))
            {
                ViewBag.Id = id;
                return View(sp);
            }
            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        public ActionResult Edit(SanPham sp, HttpPostedFileBase Anh)
        {
            if (Anh != null)
                if (Anh.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(Anh.FileName);
                    if (fileName != null && fileName != sp.Anh)
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/Images/product/"), fileName);
                        Anh.SaveAs(path);
                    }

                }
            DatabaseEntities db = new DatabaseEntities();
            SanPham sanpham = db.SanPham.Where(t => t.MaSP == sp.MaSP).FirstOrDefault();
            if (sp.Anh != null)
            {
                sanpham.Anh = sp.Anh;
            }
            if (sp.MaLoai != null)
            {
                sanpham.MaLoai = sp.MaLoai;
            }
            if (sp.Brand != null)
            {
                sanpham.BrandId = sp.BrandId;
            }
            sanpham.TenSP = sp.TenSP;
            sanpham.Gia = sp.Gia;
            sanpham.ThongTinSP = sp.ThongTinSP;
            sanpham.SoLuong = sp.SoLuong;
            db.SanPham.Add(sp);
            return RedirectToAction("Index", "Product");
        }
        public ActionResult Delete(int? id)
        {
            DatabaseEntities db = new DatabaseEntities();
            List<SanPham> sp = db.SanPham.ToList();
            if (id != null && sp.Any(t => t.MaSP == id))
            {
                ViewBag.Id = id;
                return View();
            }
            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        public ActionResult Delete(SanPham sp)
        {
            if (sp != null)
            {
                DatabaseEntities db = new DatabaseEntities();
                SanPham sanpham = db.SanPham.Where(t => t.MaSP == sp.MaSP).FirstOrDefault();
                db.SanPham.Remove(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

    }
}