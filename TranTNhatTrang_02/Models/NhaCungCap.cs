using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TranTNhatTrang_02.Models
{
    public class NhaCungCap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }

    }
}