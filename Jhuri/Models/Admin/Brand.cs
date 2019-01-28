using Jhuri.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.Models.Admin
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }

    public class BrandMap
    {
        public BrandMap(EntityTypeBuilder<Brand> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(b => b.Id);
            entityTypeBuilder.Property(b => b.Name);
            entityTypeBuilder.Property(b => b.Description);

        }
    }
}
