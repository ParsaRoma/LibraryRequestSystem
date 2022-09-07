using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Data.EntitiesConfigs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Data.data
{
    public class ApplicationDbContext : DbContext, IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private readonly string MyDb1 = "Data Source=DESKTOP-E1O540S;Initial Catalog=EFCoreKetab_DB; Integrated Security = True";
        public ApplicationDbContext() : base()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(MyDb1);
            return new ApplicationDbContext(optionsBuilder.Options);
        }

        public DbSet<Books> books { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<BookShelf> bookShelves { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(MyDb1);
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new BookShelfConfig());
            modelBuilder.ApplyConfiguration(new ShelfConfigs());
            modelBuilder.ApplyConfiguration(new UsersConfig());
         }
    }
}   