using Jhuri.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.Models.Admin
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }

    public class CountryMap
    {
        public CountryMap(EntityTypeBuilder<Country> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Name);
        }
    }
}
