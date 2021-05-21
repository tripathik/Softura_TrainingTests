using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDetails.Models
{
    public class PersonContext:DbContext
    {
        public PersonContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person() { Id = 1, Name = "Ramu", Age = 23, Qualification = "Graduate", IsEmployeed = "Yes", NoticePeriod = "3 Month", CurrentCTC = 240321 });
        }
    }
}
