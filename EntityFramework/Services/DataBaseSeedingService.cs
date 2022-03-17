using EntityFramework.Data;
using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Services
{
    public class DataBaseSeedingService
    {
        private readonly ApplicationDbContext _context;
        private DataBaseSeeds dataBaseSeeds;

        public DataBaseSeedingService(ApplicationDbContext context)
        {
            _context = context;
            dataBaseSeeds = new DataBaseSeeds();
        }

        public void SeedDatabase()
        {
            foreach(var Country in dataBaseSeeds.CountrySeedList)
            {
                _context.Countries.Add(Country);
            }
            foreach (var City in dataBaseSeeds.CitySeedList)
            {
                _context.Cities.Add(City);
            }
            foreach (var Person in dataBaseSeeds.PersonSeedList)
            {
                _context.People.Add(Person);
            }
            foreach (var Language in dataBaseSeeds.LanguageSeedList)
            {
                _context.Languages.Add(Language);
            }
            foreach (var PersonLanguage in dataBaseSeeds.PersonLanguageSeedList)
            {
                _context.PersonLanguages.Add(PersonLanguage);
            }

            _context.SaveChanges();
        }
    }
}
