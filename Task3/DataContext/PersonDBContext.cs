using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3.Entities;

namespace Task3.DataContext
{
    public class PersonDBContext:DbContext
    {
        public PersonDBContext(DbContextOptions<PersonDBContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        
    }
}
