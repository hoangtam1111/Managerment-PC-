namespace WebPC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPKTableCTDH : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CTDHs", new[] { "DonHang_MaDH" });
            DropColumn("dbo.CTDHs", "MaDH");
            RenameColumn(table: "dbo.CTDHs", name: "DonHang_MaDH", newName: "MaDH");
            DropPrimaryKey("dbo.CTDHs");
            AlterColumn("dbo.CTDHs", "MaDH", c => c.Long());
            AlterColumn("dbo.CTDHs", "MaCTHD", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.CTDHs", "MaCTHD");
            CreateIndex("dbo.CTDHs", "MaDH");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CTDHs", new[] { "MaDH" });
            DropPrimaryKey("dbo.CTDHs");
            AlterColumn("dbo.CTDHs", "MaCTHD", c => c.Long(nullable: false));
            AlterColumn("dbo.CTDHs", "MaDH", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.CTDHs", "MaDH");
            RenameColumn(table: "dbo.CTDHs", name: "MaDH", newName: "DonHang_MaDH");
            AddColumn("dbo.CTDHs", "MaDH", c => c.Long(nullable: false, identity: true));
            CreateIndex("dbo.CTDHs", "DonHang_MaDH");
        }
    }
}
