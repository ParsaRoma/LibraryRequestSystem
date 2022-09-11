using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Presentation.Auth
{
    public class applicationDbContext : IdentityDbContext<IdentityUser>, IDesignTimeDbContextFactory<applicationDbContext>
    {
        public applicationDbContext() : base()
        {

        }
        public applicationDbContext(DbContextOptions<applicationDbContext> options) : base(options)
        {
          
        }

        public applicationDbContext CreateDbContext(string[] args)
        {
              var optionsBuilder = new DbContextOptionsBuilder<applicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-E1O540S;Initial Catalog=EFCoreKetab_DB; Integrated Security = True");
            return new applicationDbContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

       
        
    }
}