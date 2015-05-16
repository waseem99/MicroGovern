namespace MicroGovern.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimaryRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PrimaryRole", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "PrimaryRole");
        }
    }
}
