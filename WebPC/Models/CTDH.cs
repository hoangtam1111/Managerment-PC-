using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPC.Models
{
    public class CTDH
   {
        [Key]
        public long MaCTHD { get; set; }

        public Nullable<long> MaDH { get; set; }
        public Nullable<long> MaSP { get; set; }
        [Required]
        public long SoLuong { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual DonHang DonHang { get; set; }
    }
}