namespace WebPC.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropcolNoiSinh : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "NoiSinh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "NoiSinh", c => c.String());
        }
    }
}
