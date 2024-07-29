namespace WebPC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableDSSP : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CTDHs", "MaDH", "dbo.DonHangs");
            DropIndex("dbo.CTDHs", new[] { "MaDH" });
            DropPrimaryKey("dbo.CTDHs");
            CreateTable(
                "dbo.DSSPs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        MaSP = c.Long(),
                        SoLuong = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SanPhams", t => t.MaSP)
                .Index(t => t.MaSP);
            
            AddColumn("dbo.CTDHs", "DonHang_MaDH", c => c.Long());
            AlterColumn("dbo.CTDHs", "MaDH", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.CTDHs", "MaDH");
            CreateIndex("dbo.CTDHs", "DonHang_MaDH");
            AddForeignKey("dbo.CTDHs", "DonHang_MaDH", "dbo.DonHangs", "MaDH");
            DropColumn("dbo.CTDHs", "MaCTHD");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CTDHs", "MaCTHD", c => c.Long(nullable: false, identity: true));
            DropForeignKey("dbo.CTDHs", "DonHang_MaDH", "dbo.DonHangs");
            DropForeignKey("dbo.DSSPs", "MaSP", "dbo.SanPhams");
            DropIndex("dbo.DSSPs", new[] { "MaSP" });
            DropIndex("dbo.CTDHs", new[] { "DonHang_MaDH" });
            DropPrimaryKey("dbo.CTDHs");
            AlterColumn("dbo.CTDHs", "MaDH", c => c.Long());
            DropColumn("dbo.CTDHs", "DonHang_MaDH");
            DropTable("dbo.DSSPs");
            AddPrimaryKey("dbo.CTDHs", "MaCTHD");
            CreateIndex("dbo.CTDHs", "MaDH");
            AddForeignKey("dbo.CTDHs", "MaDH", "dbo.DonHangs", "MaDH");
        }
    }
}
