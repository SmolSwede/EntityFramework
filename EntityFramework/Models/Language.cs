using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Language
    {
        [Key]
        public int LangID { get; set; }

        public string LangName { get; set; }

        public ICollection<PersonLanguage> PersonLanguages { get; set; }
    }
}
