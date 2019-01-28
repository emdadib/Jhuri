using Jhuri.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.Models.Admin
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<ApplicationUsers> Users { get; set; }

    }

    public class CityMap
    {
        public CityMap(EntityTypeBuilder<City> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Name);
            entityTypeBuilder.HasOne(x => x.Country).WithMany(x => x.Cities).HasForeignKey(x => x.CountryId);
        }
    }
}
