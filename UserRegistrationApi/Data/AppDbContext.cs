using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserRegistration.Models;
using UserRegistrationApi.Models;

namespace UserRegistrationApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Nutri> Nutris { get; set; }
        public DbSet<DetailUser> DetailUsers { get; set; }
    }
}
