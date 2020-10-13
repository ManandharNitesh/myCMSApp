using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelService;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {            //option will be passed to base constructor and while creating Db it will look for all the option that we are passing

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //At ;east 2 roles by default
            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Administrator", NormalizedName = "ADMINISTRATOR", RoleName = "Administrator", Handle = "administrator", RoleIcon = "/uploads/roles/icons/default/role.png", IsActive = true },
                new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER", RoleName = "customer", Handle = "customer", RoleIcon = "/uploads/roles/icons/default/role.png", IsActive = true }
            );
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } //dbSet for CRUD Operations and use Linq Queries
        public DbSet<AddressModel> Addresses { get; set; }
    }
}
