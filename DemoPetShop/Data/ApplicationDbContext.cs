using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DemoPetShop.Models;

namespace DemoPetShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DemoPetShop.Models.Category>? Category { get; set; }
        public DbSet<DemoPetShop.Models.Brand>? Brand { get; set; }
        public DbSet<DemoPetShop.Models.Product>? Product { get; set; }
        public DbSet<DemoPetShop.Models.Page>? Page { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}