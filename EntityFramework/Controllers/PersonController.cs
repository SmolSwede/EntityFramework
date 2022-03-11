﻿using EntityFramework.Models;
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

        public PersonController()
        {
            personService = new PersonService();
        }
        
        [HttpGet]
        public IActionResult Index()
        {
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



    }
}
