using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebPC.Models
{
    public class DatabaseEntities : DbContext
    {
        public DatabaseEntities() : base("MyConnect") { }
        public DbSet<LoaiSP> LoaiSP { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<DonHang> DonHang { get; set; }
        public DbSet<CTDH> CTDH { get; set; }
        public DbSet<DSSP> DSSP { get; set; }
    }
}