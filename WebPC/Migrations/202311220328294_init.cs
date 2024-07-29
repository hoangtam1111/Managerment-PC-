namespace WebPC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonHangs", "MaUser", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonHangs", "MaUser", c => c.Long(nullable: false));
        }
    }
}
