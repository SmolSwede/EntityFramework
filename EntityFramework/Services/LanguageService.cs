using EntityFramework.Data;
using EntityFramework.Models;
using EntityFramework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Services
{
    public class LanguageService
    {
        private readonly ApplicationDbContext _context;

        public LanguageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Language> Read()
        {
            List<Language> Languages = new List<Language>();

            if (_context.Languages.Count() != 0)
            {
                Languages = _context.Languages.ToList();
            }

            return Languages;
        }

        public Language Read(int id)
        {
            return _context.Languages.Find(id);
        }

        public Language Create(CreateLanguageViewModel createLanguageVM)
        {
            bool exists = _context.Languages.Any(language => language.LangName == createLanguageVM.LangName);

            if (exists)
            {
                return null;
            }

            Language newLanguage = new Language()
            {
                LangName = createLanguageVM.LangName,
            };

            _context.Languages.Add(newLanguage);
            _context.SaveChanges();

            return newLanguage;
        }

        public PersonLanguage CreateLanguageBond(CreateLanguageViewModel createLanguageVM)
        {
            bool exists = _context.Languages.Any(language => language.LangID == createLanguageVM.LangID)
                && _context.People.Any(person => person.PersonID == createLanguageVM.PersonID);

            if (exists)
            {
                PersonLanguage newPersonLanguage = new PersonLanguage()
                {
                    PersonID = createLanguageVM.PersonID,
                    LangID = createLanguageVM.LangID,
                };

                _context.PersonLanguages.Add(newPersonLanguage);
                _context.SaveChanges();

                return newPersonLanguage;
            }

            return null;
        }


        public bool Remove(int id)
        {
            Language original = Read(id);

            if (original == null)
            {
                return false;
            }

            _context.Languages.Remove(original);
            _context.SaveChanges();

            return true;
        }
    }
}
