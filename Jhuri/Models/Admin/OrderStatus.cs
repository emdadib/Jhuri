using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jhuri.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Jhuri.Models.Admin
{
    public class OrderStatus : BaseEntity
    {

        public int OrderId { get; set; }
        public int StatusId { get; set; }
        public string UserId { get; set; }

        public virtual Orders Orders { get; set; }
        public virtual Status Status { get; set; }
        public virtual ApplicationUsers Users { get; set; }
    }
    public class OrderStatusMap
    {
        public OrderStatusMap(EntityTypeBuilder<OrderStatus> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.AddedDate)
                .HasDefaultValue(DateTime.Now);
            entityTypeBuilder.HasOne(x => x.Orders)
                .WithOne(x => x.OrderStatus)
                .HasForeignKey<OrderStatus>(x => x.OrderId);
            entityTypeBuilder.HasOne(x => x.Status)
                .WithOne(x => x.OrderStatus)
                .HasForeignKey<OrderStatus>(x => x.StatusId);
            entityTypeBuilder.HasOne(x => x.Users)
                .WithMany(x => x.OrderStatuses)
                .HasForeignKey(x => x.UserId);
        }
    }
}
