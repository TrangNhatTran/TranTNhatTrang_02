using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TranTNhatTrang_02.Models
{
    public class SanPham
    {
        [Key]
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string TenNhaCungCap { get; set; }
    }
}