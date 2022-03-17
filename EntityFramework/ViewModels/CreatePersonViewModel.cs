using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.ViewModels
{
    public class CreatePersonViewModel
    {
        public int PersonID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Place of Origin")]
        public int City { get; set; }

        public List<Person> PeopleList = new List<Person>();

        public CreatePersonViewModel()
        {
        }

        public CreatePersonViewModel(string firstName, string lastName, int city)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
        }
    }
}
