namespace HL.Data.Migrations
{
    using Core.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HL.Data.NorthwindContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HL.Data.NorthwindContext context)
        {
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

            context.Customers.AddOrUpdate(new Customer { CustomerID = "AS001", Address = "TDT", City = "HCM", CompanyName = "Aswig", ContactName = "Hoang Le", ContactTitle = "Developer", Country = "VN" });
            context.Categories.AddOrUpdate(new Category { CategoryID = 1, CategoryName="Electronic",Description="Electronic XXX"});

            // Orders
            Order order = new Order { CustomerID = "AS001",OrderID=1,ShipAddress="35 TDT Q1 HCMC VN" };
            context.Orders.AddOrUpdate(order);

            context.SaveChanges();
        }
    }
}
