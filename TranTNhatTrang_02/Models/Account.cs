namespace TranTNhatTrang_02.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        public int AccountId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [StringLength(20)]
        public string RoleId { get; set; }
    }
}
