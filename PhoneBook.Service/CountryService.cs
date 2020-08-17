using PhoneBook.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhoneBook.Service
{
    public class CountryService
    {
        private PersonContext personContext;
        public CountryService()
        {
            personContext = new PersonContext();
        }
        public IEnumerable<Country> GetCountries()
        {
            return personContext.Countries.Where(c => c.IsActive.Equals(true));
        }

        public IEnumerable<Country> AddCountries(Country country)
        {
            personContext.Countries.Add(country);
            personContext.SaveChanges();
            return personContext.Countries.Where(c => c.IsActive.Equals(true));
        }

        public Country UpdateCountries(Country country)
        {
            var existingCountry = personContext.Countries.FirstOrDefault(x => x.CountryId == country.CountryId);
            if (existingCountry == null)
            {
                throw new InvalidOperationException("Country Id NotFound");
            }
            existingCountry.CountryName = country.CountryName;
            personContext.SaveChanges();
            return country;
        }
        public Country DeleteCountries(int id)
        {
            var val = personContext.Countries.Single(x => x.CountryId.Equals(id));
            if (val == null)
            {
                throw new InvalidOperationException("Country Id NotFound");
            }
            val.IsActive = false;
            personContext.SaveChanges();
            return val;

        }
    }
}
