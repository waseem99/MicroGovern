namespace MicroGovern.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inheritance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ARequests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        RequestIniated = c.DateTime(nullable: false),
                        Details = c.String(nullable: false),
                        MinRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WorkDueDate = c.DateTime(nullable: false),
                        WorkableTimeRange = c.Time(nullable: false, precision: 7),
                        PicURL = c.String(),
                        BidsVisibility = c.Boolean(nullable: false),
                        CommunityName = c.String(),
                        CommunityName1 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RequestServices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        providedService_ID = c.Int(),
                        ARequest_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Services", t => t.providedService_ID)
                .ForeignKey("dbo.ARequests", t => t.ARequest_ID)
                .Index(t => t.providedService_ID)
                .Index(t => t.ARequest_ID);
            
            CreateTable(
                "dbo.UserServices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        providedService_ID = c.Int(),
                        UserDetails_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Services", t => t.providedService_ID)
                .ForeignKey("dbo.UserDetails", t => t.UserDetails_ID)
                .Index(t => t.providedService_ID)
                .Index(t => t.UserDetails_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserServices", "UserDetails_ID", "dbo.UserDetails");
            DropForeignKey("dbo.UserServices", "providedService_ID", "dbo.Services");
            DropForeignKey("dbo.RequestServices", "ARequest_ID", "dbo.ARequests");
            DropForeignKey("dbo.RequestServices", "providedService_ID", "dbo.Services");
            DropIndex("dbo.UserServices", new[] { "UserDetails_ID" });
            DropIndex("dbo.UserServices", new[] { "providedService_ID" });
            DropIndex("dbo.RequestServices", new[] { "ARequest_ID" });
            DropIndex("dbo.RequestServices", new[] { "providedService_ID" });
            DropTable("dbo.UserServices");
            DropTable("dbo.RequestServices");
            DropTable("dbo.ARequests");
        }
    }
}
