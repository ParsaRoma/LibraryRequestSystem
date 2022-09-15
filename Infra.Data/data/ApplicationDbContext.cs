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
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>, IDesignTimeDbContextFactory<ApplicationDbContext>
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

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(MyDb1);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BookConfig());
            builder.ApplyConfiguration(new BookShelfConfig());
            builder.ApplyConfiguration(new ShelfConfigs());
            builder.ApplyConfiguration(new UsersConfig());
            //down we set UserClaims for authorazation
<<<<<<< HEAD
            // builder.Entity<AppUserClaim>().HasData
            // (
            //     new AppUserClaim() {id=1, ClaimType=Constants.Admin, ClaimValue=Constants.User,DateCreated=DateTime.UtcNow, DateModified=DateTime.UtcNow},
            // );   
=======
            builder.Entity<AppUserClaim>().HasData
        
        # region Configure Claim Tables and add admin
        (
        new AppUserClaim() {id=1, ClaimType=Constants.ROLE_ADMIN, ClaimValue=Constants.ADD_USER_CLAIM_VALUE,DateCreated=DateTime.UtcNow, DateModified=DateTime.UtcNow},
        new AppUserClaim() {id=2, ClaimType=Constants.ROLE_ADMIN, ClaimValue=Constants.EDIT_USER_CLAIM_VALUE,DateCreated=DateTime.UtcNow, DateModified=DateTime.UtcNow},
        new AppUserClaim() {id=3, ClaimType=Constants.ROLE_ADMIN, ClaimValue=Constants.DELETE_USER_CLAIM_VALUE,DateCreated=DateTime.UtcNow, DateModified=DateTime.UtcNow},
        new AppUserClaim() {id=4, ClaimType=Constants.ROLE_ADMIN, ClaimValue=Constants.GET_USER_CLAIM_VALUE,DateCreated=DateTime.UtcNow, DateModified=DateTime.UtcNow},

        new AppUserClaim() {id=5, ClaimType=Constants.ROLE_USER, ClaimValue=Constants.ADD_BOOK_CLAIM_VALUE,DateCreated=DateTime.UtcNow, DateModified=DateTime.UtcNow},
        new AppUserClaim() {id=6, ClaimType=Constants.ROLE_USER, ClaimValue=Constants.EDIT_BOOK_CLAIM_VALUE,DateCreated=DateTime.UtcNow, DateModified=DateTime.UtcNow},
        new AppUserClaim() {id=7, ClaimType=Constants.ROLE_USER, ClaimValue=Constants.DELETE_BOOK_CLAIM_VALUE,DateCreated=DateTime.UtcNow, DateModified=DateTime.UtcNow},
        new AppUserClaim() {id=8, ClaimType=Constants.ROLE_USER, ClaimValue=Constants.GET_BOOK_CLAIM_VALUE,DateCreated=DateTime.UtcNow, DateModified=DateTime.UtcNow}

        ); 
        builder.Entity<IdentityRole<int>>().HasData
        (
            new IdentityRole<int>() {Id=1, Name= Constants.ROLE_ADMIN, NormalizedName= Constants.ROLE_ADMIN.ToUpper()},
             new IdentityRole<int>() {Id=2, Name= Constants.ROLE_USER, NormalizedName= Constants.ROLE_USER.ToUpper()}
        );
        
        var adminUser = new AppUser()
        {
            Id = 1,
            UserName = "admin@admin.com",
            Email = "admin@admin.com",
            FullName = "ShahidParsa",
            DataCreated = DateTime.UtcNow};
            adminUser.PasswordHash = new PasswordHasher<AppUser>().HashPassword(adminUser, "1234@Qaz");
            builder.Entity<AppUser>().HasData(adminUser);
        
         builder.Entity<IdentityRole<int>>().HasData
        (
            new IdentityUserRole<int>() {UserId=1, RoleId=1}
        );
        
        

builder.Entity<IdentityUserClaim<int>>().HasData       
(
    new IdentityUserClaim<int>() {Id=1, UserId=1, ClaimType= Constants.ROLE_ADMIN, ClaimValue=Constants.ADD_USER_CLAIM_VALUE},
    new IdentityUserClaim<int>() {Id=2, UserId=1, ClaimType= Constants.ROLE_ADMIN, ClaimValue=Constants.EDIT_USER_CLAIM_VALUE},
    new IdentityUserClaim<int>() {Id=3, UserId=1, ClaimType= Constants.ROLE_ADMIN, ClaimValue=Constants.DELETE_USER_CLAIM_VALUE},
    new IdentityUserClaim<int>() {Id=4, UserId=1, ClaimType= Constants.ROLE_ADMIN, ClaimValue=Constants.GET_USER_CLAIM_VALUE}, 
    
    new IdentityUserClaim<int>() {Id=5, UserId=1, ClaimType= Constants.ROLE_USER, ClaimValue=Constants.ADD_BOOK_CLAIM_VALUE},
    new IdentityUserClaim<int>() {Id=6, UserId=1, ClaimType= Constants.ROLE_USER, ClaimValue=Constants.EDIT_BOOK_CLAIM_VALUE},
    new IdentityUserClaim<int>() {Id=7, UserId=1, ClaimType= Constants.ROLE_USER, ClaimValue=Constants.DELETE_BOOK_CLAIM_VALUE},
    new IdentityUserClaim<int>() {Id=8, UserId=1, ClaimType= Constants.ROLE_USER, ClaimValue=Constants.GET_USER_CLAIM_VALUE}  

    #endregion
);

}
>>>>>>> master

        public DbSet<Books> books { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<BookShelf> bookShelves { get; set; }
    }
}