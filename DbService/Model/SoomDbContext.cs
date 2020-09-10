using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace DbServices.Model
{
    public class SoomDbContext : IdentityDbContext<Users>
    {
        public SoomDbContext(DbContextOptions<SoomDbContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<SubCategory> SubCategorys { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
