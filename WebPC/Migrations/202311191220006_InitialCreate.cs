namespace WebPC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Long(nullable: false, identity: true),
                        BrandName = c.String(nullable: false),
                        BrandLogo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        MaSP = c.Long(nullable: false, identity: true),
                        TenSP = c.String(nullable: false),
                        Gia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThongTinSP = c.String(nullable: false),
                        Anh = c.String(),
                        SoLuong = c.Long(nullable: false),
                        MaLoai = c.Long(nullable: false),
                        BrandId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.LoaiSPs", t => t.MaLoai, cascadeDelete: true)
                .Index(t => t.MaLoai)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.CTDHs",
                c => new
                    {
                        MaCTHD = c.Long(nullable: false, identity: true),
                        MaDH = c.Long(),
                        MaSP = c.Long(),
                        SoLuong = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MaCTHD)
                .ForeignKey("dbo.DonHangs", t => t.MaDH)
                .ForeignKey("dbo.SanPhams", t => t.MaSP)
                .Index(t => t.MaDH)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.DonHangs",
                c => new
                    {
                        MaDH = c.Long(nullable: false, identity: true),
                        NgayDat = c.DateTime(),
                        MaUser = c.Long(nullable: false),
                        TongTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaDH);
            
            CreateTable(
                "dbo.LoaiSPs",
                c => new
                    {
                        MaLoai = c.Long(nullable: false, identity: true),
                        TenLoai = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaLoai);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "MaLoai", "dbo.LoaiSPs");
            DropForeignKey("dbo.CTDHs", "MaSP", "dbo.SanPhams");
            DropForeignKey("dbo.CTDHs", "MaDH", "dbo.DonHangs");
            DropForeignKey("dbo.SanPhams", "BrandId", "dbo.Brands");
            DropIndex("dbo.CTDHs", new[] { "MaSP" });
            DropIndex("dbo.CTDHs", new[] { "MaDH" });
            DropIndex("dbo.SanPhams", new[] { "BrandId" });
            DropIndex("dbo.SanPhams", new[] { "MaLoai" });
            DropTable("dbo.LoaiSPs");
            DropTable("dbo.DonHangs");
            DropTable("dbo.CTDHs");
            DropTable("dbo.SanPhams");
            DropTable("dbo.Brands");
        }
    }
}
