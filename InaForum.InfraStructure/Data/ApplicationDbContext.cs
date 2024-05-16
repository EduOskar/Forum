using InaForum.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InaForum.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(u => u.Id);
            });

            modelBuilder.Entity<User>().HasData(
                new User("Oskar", "Ahling", "Klade", "Hejsan123!", "Oskar@Mail.com")
                {
                },
                new User("Ina", "Nilsson", "Nubbebub", "Hejsan123!", "Ina@Mail.com")
                {

                }
            );
            
        }

        
    }
}
