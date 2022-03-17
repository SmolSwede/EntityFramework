using EntityFramework.Data;
using EntityFramework.Models;
using EntityFramework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Services
{
    public class CountryService
    {
        private readonly ApplicationDbContext _context;

        public CountryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Country> Read()
        {
            List<Country> countries = new List<Country>();

            if (_context.Countries.Count() != 0)
            {
                countries = _context.Countries.ToList();
            }

            return countries;
        }

        public Country Read(int id)
        {
            return _context.Countries.Find(id);
        }

        public Country Create(CreateCountryViewModel createCountryVM)
        {
            Country newCountry = new Country()
            {
                CountryName = createCountryVM.CountryName,
            };

            _context.Countries.Add(newCountry);
            _context.SaveChanges();

            return newCountry;
        }

        public bool Remove(int id)
        {
            Country original = Read(id);

            if (original == null)
            {
                return false;
            }

            _context.Countries.Remove(original);
            _context.SaveChanges();

            return true;
        }

    }
}
