using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebPC.Models
{
    public class SanPham
    {
        [Key]
        public long MaSP { get; set; }
        [Required]
        public string TenSP { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{#,##0}")]
        public decimal Gia { get; set; }
        [Required]
        public string ThongTinSP { get; set; }
        public string Anh { get; set; }
        [Required]
        public long SoLuong { get; set; }
        [Required]
        public Nullable<long> MaLoai { get; set; }
        [Required]
        public Nullable<long> BrandId { get; set; }
        public virtual LoaiSP LoaiSP { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<CTDH> CTDH { get; set; }
        public virtual ICollection<DSSP> DSSP { get; set; }

    }
}