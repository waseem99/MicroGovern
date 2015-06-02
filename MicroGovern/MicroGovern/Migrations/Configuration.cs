namespace MicroGovern.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MicroGovern.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MicroGovern.Models.ApplicationDbContext";
        }

        protected override void Seed(MicroGovern.Models.ApplicationDbContext context)
        {
            //context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = "Admin" });
            //context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = "User" });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
