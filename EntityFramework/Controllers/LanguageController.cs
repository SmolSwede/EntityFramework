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
    public class LanguageController : Controller
    {
        private LanguageService languageService;
        private PersonService personService;

        private readonly ApplicationDbContext _context;

        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
            languageService = new LanguageService(_context);
            personService = new PersonService(_context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            CreateLanguageViewModel createLanguageVM = new CreateLanguageViewModel();

            if (languageService.Read() != null)
            {
                createLanguageVM.LanguageList = languageService.Read();
                createLanguageVM.PeopleList = personService.Read();
            }

            return View(createLanguageVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLanguage(CreateLanguageViewModel createLanguageVM)
        {
            if (ModelState.IsValid)
            {
                Language language = languageService.Create(createLanguageVM);

                if (language != null)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("Storage", "Failed to save person");
            }

            return View("Index", createLanguageVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLanguageBond(CreateLanguageViewModel createLanguageVM)
        {
            if (ModelState.IsValid)
            {
                PersonLanguage personLanguage = languageService.CreateLanguageBond(createLanguageVM);

                if (personLanguage != null)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("Storage", "Failed to save person");
            }

            return View("Index", createLanguageVM);
        }

        public IActionResult Remove(int id)
        {
            languageService.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
