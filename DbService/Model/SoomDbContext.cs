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
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
