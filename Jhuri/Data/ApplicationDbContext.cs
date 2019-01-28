using Jhuri.Models;
using Jhuri.Models.Admin;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers, ApplicationRoles, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<ProductComments> ProductComments { get; set; }
        public virtual DbSet<ProductImage> ProductImage { get; set; }
        public virtual DbSet<ProductManual> ProductManual { get; set; }
        public virtual DbSet<ProductStock> ProductStock { get; set; }
        public virtual DbSet<Orders> Order { get; set; }
        public virtual DbSet<OrderDetails>  OrderDetails { get; set; }
        public virtual DbSet<OrderStatus>  OrderStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Brand>().ToTable("Brand");
            builder.Entity<Category>().ToTable("Category");
            builder.Entity<Country>().ToTable("Country");
            builder.Entity<City>().ToTable("City");
            builder.Entity<Users>().ToTable("Users");
            builder.Entity<ApplicationUsers>().HasOne(x => x.City).WithMany(x => x.Users).HasForeignKey(x => x.CityId);

            //Mapping Tables

            new BrandMap(builder.Entity<Brand>());
            new CategoryMap(builder.Entity<Category>());
            new CountryMap(builder.Entity<Country>());
            new CityMap(builder.Entity<City>());
            new LocationMap(builder.Entity<Location>());
            new PaymentMethodMap(builder.Entity<PaymentMethod>());
            new UnitMap(builder.Entity<Unit>());
            new ProductMap(builder.Entity<Product>());
            new ProductCommentsMap(builder.Entity<ProductComments>());
            new ProductImageMap(builder.Entity<ProductImage>());
       
            new ProductImageMap(builder.Entity<ProductImage>());
            new ProductLikesMap(builder.Entity<ProductLikes>());
            new ProductManualMap(builder.Entity<ProductManual>());
            new ProductStockMap(builder.Entity<ProductStock>());

            new OrdersMap(builder.Entity<Orders>());
            new OrderDetailsMap(builder.Entity<OrderDetails>());
            new OrderStatusMap(builder.Entity<OrderStatus>());
        }
    }
}
