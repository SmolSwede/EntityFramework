using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.ViewModels
{
    public class CreateCountryViewModel
    {
        public int CountryID { get; set; }

        [Required]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        public List<Country> CountryList = new List<Country>();

        public CreateCountryViewModel()
        {
        }

        public CreateCountryViewModel(string countryName)
        {
            CountryName = countryName;
        }
    }
}
