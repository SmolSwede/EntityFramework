﻿using EntityFramework.Data;
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
    public class PersonController : Controller
    {
        private PersonService personService;
        private DataBaseSeedingService databaseSeedingService;

        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
            personService = new PersonService(_context);
            databaseSeedingService = new DataBaseSeedingService(_context);
        }

    [HttpGet]
        public IActionResult Index()
        {

            //databaseSeedingService.SeedDatabase();


            CreatePersonViewModel createPersonVM = new CreatePersonViewModel();

            if(personService.Read() != null)
            {
                createPersonVM.PeopleList = personService.Read();
            }

            return View(createPersonVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePerson(CreatePersonViewModel createPersonVM)
        {
            if (ModelState.IsValid)
            {
                Person person = personService.Create(createPersonVM);

                if(person != null)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("Storage", "Failed to save person");
            }

            return View("Index", createPersonVM);
        }

        public IActionResult Remove(int id)
        {
            personService.Remove(id);

            return RedirectToAction(nameof(Index));
        }



    }
}
