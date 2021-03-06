﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jhuri.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jhuri.Models.Admin
{
    public class Orders : BaseEntity
    {
        public string Number { get; set; }
        public string UserId { get; set; }
        public double Total { get; set; }
        public double DeliveryCharge { get; set; }
        public double OthersCharge { get; set; }
        public int PaymentMethodId { get; set; }
        public string DeliveryAddress { get; set; }
        public int LocationId { get; set; }

        public virtual ApplicationUsers Users { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Location Location { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

    }

    public class OrdersMap
    {
        public OrdersMap(EntityTypeBuilder<Orders> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Number).HasMaxLength(100);
            entityTypeBuilder.Property(x => x.Total);
            entityTypeBuilder.Property(x => x.DeliveryCharge);
            entityTypeBuilder.Property(x => x.OthersCharge);
            entityTypeBuilder.Property(x => x.DeliveryAddress).HasMaxLength(200);

            entityTypeBuilder.HasOne(x => x.Users)
                .WithMany(x => x.Orderses)
                .HasForeignKey(x => x.UserId);
            entityTypeBuilder.HasOne(x => x.PaymentMethod)
                .WithMany(x => x.Orderses)
                .HasForeignKey(x => x.PaymentMethodId);
            entityTypeBuilder.HasOne(x => x.Location)
                .WithMany(x => x.Orderses)
                .HasForeignKey(x => x.LocationId);
        }
    }

}
