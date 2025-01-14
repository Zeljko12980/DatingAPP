using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext :IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Destinacija> Destinacije {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

             builder.Entity<Destinacija>()
        .Property(d => d.Id)
        .ValueGeneratedOnAdd();
        }

    }
}
