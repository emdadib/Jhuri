using Jhuri.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.Models.Admin
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int? CategoryId { get; set; }
        public Category Categoris { get; set; }
        public ICollection<Category> CategoriesList { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    public class CategoryMap
    {
        public CategoryMap(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Name);
            entityTypeBuilder.Property(x => x.Description);
            entityTypeBuilder.HasOne(x => x.Categoris).WithMany(x => x.CategoriesList).HasForeignKey(x => x.CategoryId).IsRequired(false);
        }
    }
}
