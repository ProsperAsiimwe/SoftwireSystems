namespace Softwire.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "DOB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DOB", c => c.DateTime());
        }
    }
}
