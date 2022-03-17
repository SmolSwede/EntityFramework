using EntityFramework.Data;
using EntityFramework.Models;
using EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.ViewModels
{
    public class CreateCityViewModel
    {
        public int CityID { get; set; }

        [Required]
        [Display(Name = "City Name")]
        public string CityName { get; set; }

        [Required]
        [Display(Name = "City Location")]
        public int Country { get; set; }

        public List<City> CityList = new List<City>();

        public CreateCityViewModel()
        {
        }

        public CreateCityViewModel(string cityName, int country)
        {
            CityName = cityName;
            Country = country;
        }

    }
}
