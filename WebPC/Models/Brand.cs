using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPC.Models
{
    public class Brand
    {
        [Key]
        public long BrandId { get; set; }
        [Required]
        public string BrandName { get; set; }
        [Required]
        public string BrandLogo { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}