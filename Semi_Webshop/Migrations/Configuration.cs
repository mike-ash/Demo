namespace Semi_Webshop.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Semi_Webshop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Semi_Webshop.Models.ApplicationDbContext";
        }

        protected override void Seed(Semi_Webshop.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Movies.AddOrUpdate(
            //  p => p.Name,
            //  new Movie { Name = "" },
            //  new Movie { Name = "Brice Lambson" },
            //  new Movie { Name = "Rowan Miller" }
            //);

        }
    }
}
