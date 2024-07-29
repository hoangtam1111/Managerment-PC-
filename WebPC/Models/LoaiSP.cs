using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebPC.Models
{
    public class LoaiSP
    {
        [Key]
        public long MaLoai { get; set; }
        [Required]
        public string TenLoai { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}