using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ClaimHelper;
using Domain.Models;
using Domain.Models.IdentityModels;
using Infra.Data.EntitiesConfigs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Data.data
{
    public class ApplicationDbContext : IdentityDbContext, IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private readonly string MyDb1 = "Data Source=DESKTOP-E1O540S;Initial Catalog=EFCoreKetab_DB; Integrated Security = True";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>  options) : base(options)
        {

        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(MyDb1);
            return new ApplicationDbContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BookConfig());
            builder.ApplyConfiguration(new BookShelfConfig());
            builder.ApplyConfiguration(new ShelfConfigs());
            builder.ApplyConfiguration(new UsersConfig());
            //down we set UserClaims for authorazation
            // builder.Entity<AppUserClaim>().HasData
            // (
            //     new AppUserClaim() {id=1, ClaimType=Constants.Admin, ClaimValue=Constants.User,DateCreated=DateTime.UtcNow, DateModified=DateTime.UtcNow},
            // );   

        }
        public DbSet<Books> books { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<BookShelf> bookShelves { get; set; }
    }
}