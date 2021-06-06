namespace TranTNhatTrang_02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Email = c.String(),
                        Password = c.String(),
                        RoleId = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.__MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150),
                        ContextKey = c.String(nullable: false, maxLength: 300),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            CreateTable(
                "dbo.MSreplication_options",
                c => new
                    {
                        optname = c.String(nullable: false, maxLength: 128),
                        value = c.Boolean(nullable: false),
                        major_version = c.Int(nullable: false),
                        minor_version = c.Int(nullable: false),
                        revision = c.Int(nullable: false),
                        install_failures = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.optname, t.value, t.major_version, t.minor_version, t.revision, t.install_failures });
            
            CreateTable(
                "dbo.NhaCungCaps",
                c => new
                    {
                        MaNhaCungCap = c.Int(nullable: false, identity: true),
                        TenNhaCungCap = c.String(),
                    })
                .PrimaryKey(t => t.MaNhaCungCap);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NhaCungCaps");
            DropTable("dbo.MSreplication_options");
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.Accounts");
        }
    }
}
