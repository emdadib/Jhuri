using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jhuri.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Jhuri.Models.Admin
{
    public class OrderDetails : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public string Remarks { get; set; }

        public virtual Orders Orders { get; set; }
        public virtual Product Product { get; set; }
    }

    public class OrderDetailsMap
    {
        public OrderDetailsMap(EntityTypeBuilder<OrderDetails> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Quantity);
            entityTypeBuilder.Property(x => x.Rate);
            entityTypeBuilder.Property(x => x.Remarks).HasMaxLength(200);
            entityTypeBuilder.HasOne(x => x.Product).WithOne(x => x.OrderDetails)
                .HasForeignKey<OrderDetails>(x => x.ProductId);
            entityTypeBuilder.HasOne(x => x.Orders).WithOne(x => x.OrderDetails)
                .HasForeignKey<OrderDetails>(x => x.OrderId);
        }
    }
}
