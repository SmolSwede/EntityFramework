using EntityFramework.Data;
using EntityFramework.Models;
using EntityFramework.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Services
{
    public class CityService
    {
        private readonly ApplicationDbContext _context;

        public CityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<City> Read()
        {
            List<City> cities = new List<City>();

            if (_context.Cities.Count() != 0)
            {
                cities = _context.Cities.ToList();
            }

            return cities;
        }

        public City Read(int id)
        {
            return _context.Cities.Find(id);
        }

        public City Create(CreateCityViewModel createCityVM)
        {
            bool exsists = _context.Cities.Any(city => city.CityName == createCityVM.CityName);
            
            if (exsists)
            {
                return null;
            }

            City newCity = new City()
            {
                CityName = createCityVM.CityName,
                CountryID = createCityVM.Country,
            };

            _context.Cities.Add(newCity);
            _context.SaveChanges();

            return newCity;
        }

        public bool Remove(int id)
        {
            City original = Read(id);

            if (original == null)
            {
                return false;
            }

            _context.Cities.Remove(original);
            _context.SaveChanges();

            return true;
        }
    }
}
