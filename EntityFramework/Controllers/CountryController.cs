using EntityFramework.Data;
using EntityFramework.Models;
using EntityFramework.Services;
using EntityFramework.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Controllers
{
    public class CountryController : Controller
    {
        private CountryService countryService;

        private readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
            countryService = new CountryService(_context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            CreateCountryViewModel createCountryVM = new CreateCountryViewModel();

            if (countryService.Read() != null)
            {
                createCountryVM.CountryList = countryService.Read();
            }

            return View(createCountryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCountry(CreateCountryViewModel createCountryVM)
        {
            if (ModelState.IsValid)
            {
                Country country = countryService.Create(createCountryVM);

                if (country != null)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("Storage", "Failed to save person");
            }

            return View("Index", createCountryVM);
        }

        public IActionResult Remove(int id)
        {
            countryService.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
