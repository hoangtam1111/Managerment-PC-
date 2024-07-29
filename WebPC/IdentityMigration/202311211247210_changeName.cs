namespace WebPC.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "Ten");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Ten", c => c.String());
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
