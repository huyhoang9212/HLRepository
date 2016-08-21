using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.Core.Domain;
using HL.Data.Mapping;

namespace HL.Data
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
            :base("name=NorthwindContextConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NorthwindContext,
                Migrations.Configuration>("NorthwindContextConnectionString"));            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new CategoryMap());
        }
    }
}
