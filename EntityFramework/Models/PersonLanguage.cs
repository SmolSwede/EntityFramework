using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class PersonLanguage
    {
        public int PersonLanguageID { get; set; }
        public int LanguageLangID { get; set; }
        public int PersonID { get; set; }
        public int LangID { get; set; }
        public Person Person { get; set; }
        public Language Language { get; set; }
    }
}
