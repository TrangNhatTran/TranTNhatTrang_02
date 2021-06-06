namespace TranTNhatTrang_02.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LTQLDb : DbContext
    {
        public LTQLDb()
            : base("name=LTQLDb")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
       
        public virtual DbSet<MSreplication_options> MSreplication_options { get; set; }

        public System.Data.Entity.DbSet<TranTNhatTrang_02.Models.NhaCungCap> NhaCungCaps { get; set; }

        public System.Data.Entity.DbSet<TranTNhatTrang_02.Models.SanPham> SanPhams { get; set; }
    }
}
