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
    public class CityController : Controller
    {
        private CityService cityService;

        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
            cityService = new CityService(_context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            CreateCityViewModel createCityVM = new CreateCityViewModel();

            if (cityService.Read() != null)
            {
                createCityVM.CityList = cityService.Read();
            }

            return View(createCityVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCity(CreateCityViewModel createCityVM)
        {
            if (ModelState.IsValid)
            {
                City city = cityService.Create(createCityVM);

                if (city != null)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("Storage", "Failed to save person");
            }

            return View("Index", createCityVM);
        }

        public IActionResult Remove(int id)
        {
            cityService.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
