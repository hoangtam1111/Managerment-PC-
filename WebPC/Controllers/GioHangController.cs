using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPC.Models;
using WebPC.Identity;
using WebPC.Filters;
namespace WebPC.Controllers
{
    [MyAuthenFilter]
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            // Mã đơn hàng
            ViewBag.Id = 1;  
            return View();
        }
        [HttpPost]
        
        public ActionResult insertGioHang(int id,string username)
        {
            DatabaseEntities db = new DatabaseEntities();
            DSSP dssp = db.DSSP.Where(t => t.ID == id).FirstOrDefault();
            if(dssp==null)
            {
                DSSP ct = new DSSP();
                ct.MaSP = id;
                ct.SoLuong = 1;
                ct.UserName = username;
                db.DSSP.Add(ct);
                db.SaveChanges();
            }
            else
            {
                dssp.SoLuong++;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult deleteGioHang(int? id)
        {
            DatabaseEntities db = new DatabaseEntities();
            DSSP dssp = db.DSSP.Where(t => t.ID == id).FirstOrDefault();
            db.DSSP.Remove(dssp);
            return RedirectToAction("Index");
        }
        public ActionResult updateQuantity(int ProId, int SoLuong)
        {
            DatabaseEntities db = new DatabaseEntities();
            DSSP dssp = db.DSSP.Where(t => t.ID == ProId).FirstOrDefault();
            dssp.SoLuong = SoLuong;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult buy(DonHang dh)
        {
            DatabaseEntities db = new DatabaseEntities();
            dh.NgayDat = DateTime.Now;
            dh.CTDH = db.CTDH.ToList();
            db.DonHang.Add(dh);
            db.SaveChanges();
            long maDH= db.DonHang.Where(t => t.MaUser == dh.MaUser).FirstOrDefault().MaDH;
            foreach (DSSP a in db.DSSP)
            {
                CTDH ct = new CTDH();

                ct.MaDH = maDH;
                ct.MaSP = a.MaSP;
                ct.SoLuong = a.SoLuong;
                db.CTDH.Add(ct);
                db.DSSP.Remove(a);
                db.SaveChanges();
            }
            List<CTDH> dsCTDH = db.CTDH.Where(t => t.MaDH == maDH).ToList();
            return View(dsCTDH);
        }
    }
}