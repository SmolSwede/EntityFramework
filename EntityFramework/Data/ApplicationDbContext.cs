using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasKey(c => new { c.CountryID });

            modelBuilder.Entity<Country>()
                .HasMany<City>(c => c.Cities)
                .WithOne(ci => ci.Country)
                .HasForeignKey(c => c.CityID);

            modelBuilder.Entity<Country>()
                .HasData(new List<Country> { new Country { CountryID = 1, CountryName = "Sweden" },
                                             new Country { CountryID = 2, CountryName = "Norway" }, });

            modelBuilder.Entity<City>().HasKey(ci => new { ci.CityID });

            modelBuilder.Entity<City>()
                .HasOne<Country>(ci => ci.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(ci => ci.CountryID);

            modelBuilder.Entity<City>()
                .HasData(new List<City> { new City { CityID = 1, CityName = "Tibro", CountryID = 1},
                                          new City { CityID = 2, CityName = "Oslo", CountryID = 2}, });

            modelBuilder.Entity<Person>().HasKey(p => new { p.PersonID });

            modelBuilder.Entity<Person>()
                .HasOne<City>(p => p.City)
                .WithMany(ci => ci.People)
                .HasForeignKey(p => p.CityID);

            modelBuilder.Entity<Person>()
                .HasData(new List<Person> { new Person { PersonID = 1, FirstName = "Simon", LastName = "Simonsson", CityID = 1},
                                            new Person { PersonID = 2, FirstName = "Gustav", LastName = "Gustavsson", CityID = 2}, });

            modelBuilder.Entity<Language>().HasKey(l => new { l.LangID });

            modelBuilder.Entity<Language>()
                .HasData(new List<Language> { new Language { LangID = 1, LangName = "Swedish"},
                                              new Language { LangID = 2, LangName = "Norwegian"} });

            modelBuilder.Entity<PersonLanguage>().HasKey(pl => new { pl.LangID, pl.PersonID });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Language>(pl => pl.Language)
                .WithMany(l => l.PersonLanguages)
                .HasForeignKey(pl => pl.LangID);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Person>(pl => pl.Person)
                .WithMany(p => p.PersonLanguages)
                .HasForeignKey(pl => pl.PersonID);

            modelBuilder.Entity<PersonLanguage>()
                .HasData(new List<PersonLanguage> { new PersonLanguage { LangID = 1, PersonID = 1},
                                                    new PersonLanguage { LangID = 1, PersonID = 2},
                                                    new PersonLanguage { LangID = 2, PersonID = 2} });
        }
    }
}
