using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class DataBaseSeeds
    {
        public List<Country> CountrySeedList = new List<Country>
        {
            new Country { CountryName = "Sweden" },
            new Country { CountryName = "Norway" },
        };

        public List<City> CitySeedList = new List<City>()
        {
            new City { CityName = "Töreboda", CountryID = 1},
            new City { CityName = "Oslo", CountryID = 2},
        };

        public List<Person> PersonSeedList = new List<Person>()
        {
            new Person { FirstName = "Simon", LastName = "Simonsson", CityID = 1},
            new Person { FirstName = "Gustav", LastName = "Gustavsson", CityID = 2},
        };

        public List<Language> LanguageSeedList = new List<Language>()
        {
            new Language { LangName = "Swedish" },
            new Language { LangName = "Norwegian" },
        };

        public List<PersonLanguage> PersonLanguageSeedList = new List<PersonLanguage>()
        {
            new PersonLanguage { LangID = 1, PersonID = 1 },
            new PersonLanguage { LangID = 1, PersonID = 2 },
            new PersonLanguage { LangID = 2, PersonID = 2 },
        };
    }
}
