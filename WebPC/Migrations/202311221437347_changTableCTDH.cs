namespace WebPC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changTableCTDH : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CTDHs", "MaDH", "dbo.DonHangs");
            DropForeignKey("dbo.CTDHs", "MaSP", "dbo.SanPhams");
        }

        public override void Down()
        {
        }
    }
}
