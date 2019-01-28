﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.Models.Admin
{
    public class ProductLikes
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public DateTime AddedDate { get; set; }
        public virtual Product Product { get; set; }
        public virtual ApplicationUsers Users { get; set; }
    }

    public class ProductLikesMap
    {
        public ProductLikesMap(EntityTypeBuilder<ProductLikes> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new { x.ProductId, x.UserId });
            entityTypeBuilder.Property(x => x.AddedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
