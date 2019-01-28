using Jhuri.Data;
using Jhuri.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.Code
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Countries.Any())
            {
                var country = new Country[]
                {
                    new Country{Name = "Bangladesh",AddedDate = DateTime.Parse("2018-11-01"),ModifiedDate = DateTime.Parse("2018-11-01")},
                    new Country{Name = "India",AddedDate = DateTime.Parse("2018-11-01"),ModifiedDate = DateTime.Parse("2018-11-01")},
                };
                foreach (Country c in country)
                {
                    context.Countries.Add(c);
                }
                context.SaveChanges();
            }

            if (!context.Cities.Any())
            {
                var countryId = context.Countries.First(x => x.Name == "Bangladesh").Id;
                var city = new City[]
              {
                    new City{Name = "Chittagong",CountryId = countryId,AddedDate = DateTime.Parse("2018-11-01"),ModifiedDate = DateTime.Parse("2018-11-01")},
                    new City{Name = "Barishal",CountryId = countryId,AddedDate = DateTime.Parse("2018-11-01"),ModifiedDate = DateTime.Parse("2018-11-01")},
                    new City{Name = "Dhaka",CountryId = countryId,AddedDate = DateTime.Parse("2018-11-01"),ModifiedDate = DateTime.Parse("2018-11-01")},
              };
                foreach (City c in city)
                {
                    context.Cities.Add(c);
                }
                context.SaveChanges();
            }
        }
    }
}
