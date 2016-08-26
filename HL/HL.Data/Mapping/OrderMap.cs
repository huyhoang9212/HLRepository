using System;
using System.Data.Entity.ModelConfiguration;
using HL.Core.Domain;
namespace HL.Data.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.HasKey(t => t.OrderID);

            // Properties
            this.Property(t => t.CustomerID)
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.ShipName)
                .HasMaxLength(40);

            this.Property(t => t.ShipAddress)
                .HasMaxLength(60);

            this.Property(t => t.ShipCity)
                .HasMaxLength(15);

            this.Property(t => t.ShipRegion)
                .HasMaxLength(15);

            this.Property(t => t.ShipPostalCode)
                .HasMaxLength(10);

            this.Property(t => t.ShipCountry)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Orders");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.RequiredDate).HasColumnName("RequiredDate");
            this.Property(t => t.ShippedDate).HasColumnName("ShippedDate");
            this.Property(t => t.ShipVia).HasColumnName("ShipVia");
            this.Property(t => t.Freight).HasColumnName("Freight");
            this.Property(t => t.ShipName).HasColumnName("ShipName");
            this.Property(t => t.ShipAddress).HasColumnName("ShipAddress");
            this.Property(t => t.ShipCity).HasColumnName("ShipCity");
            this.Property(t => t.ShipRegion).HasColumnName("ShipRegion");
            this.Property(t => t.ShipPostalCode).HasColumnName("ShipPostalCode");
            this.Property(t => t.ShipCountry).HasColumnName("ShipCountry");

            //Relationship
            this.HasOptional(o => o.Customer)
                .WithMany(c => c.Orders)                
                .HasForeignKey(o => o.CustomerID)
                .WillCascadeOnDelete(true);
        }
    }
}
