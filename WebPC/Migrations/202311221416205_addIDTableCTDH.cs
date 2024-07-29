namespace WebPC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIDTableCTDH : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CTDHs", "MaCTHD", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CTDHs", "MaCTHD");
        }
    }
}
