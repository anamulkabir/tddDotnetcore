using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspnetCoreTDD.Models;

namespace AspnetCoreTDD.Data
{
    public class UserCredContext : DbContext
    {
        public UserCredContext (DbContextOptions<UserCredContext> options)
            : base(options)
        {
        }
        
        public DbSet<UserCred> UserCreds { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCred>().ToTable("UserCred");
        }
    }
}
