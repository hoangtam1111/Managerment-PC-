namespace WebPC.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Ten", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Ten");
        }
    }
}
