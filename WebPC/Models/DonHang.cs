using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebPC.Models
{
    public class DonHang
    {
        [Key]
        public long MaDH { get; set; }
        public Nullable<System.DateTime> NgayDat { get; set; }
        public string MaUser { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "N0")]
        public Nullable<decimal> TongTien { get; set; }
        public virtual ICollection<CTDH> CTDH { get; set; }
    }
}