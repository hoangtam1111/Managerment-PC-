using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPC.Models
{
    public class DSSP
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public Nullable<long> MaSP { get; set; }
        public long SoLuong { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}