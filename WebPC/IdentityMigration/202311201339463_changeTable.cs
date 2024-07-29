namespace WebPC.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "NgaySinh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "NgaySinh", c => c.DateTime(nullable: false));
        }
    }
}
