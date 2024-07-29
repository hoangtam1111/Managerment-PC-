using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPC.Models;
using System.IO;

namespace WebPC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
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
            int n = 12;
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
    }
}