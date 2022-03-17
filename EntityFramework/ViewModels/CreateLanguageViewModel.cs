using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.ViewModels
{
    public class CreateLanguageViewModel
    {
        public int LangID { get; set; }

        public string LangName { get; set; }

        public int PersonID { get; set; }

        public List<Language> LanguageList = new List<Language>();

        public List<Person> PeopleList = new List<Person>();

        public CreateLanguageViewModel()
        {
        }

        public CreateLanguageViewModel(string langName, int personID, int langID)
        {
            LangName = langName;
            PersonID = personID;
            LangID = langID;
        }
    }
}
