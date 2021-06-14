using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd
{
   
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } //constructor chaining where creating a constructor into the DbContext class to pass the DnContext options (child) enttity into base class (parent)
            public DbSet<UserInput> UserInput { get; set; } //will create a table in database called UserInput
            
        }
    }

