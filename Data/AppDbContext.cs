using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Tasks> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
    
        builder.Entity<Tasks>(entity =>
        {
        entity.HasOne(t => t.User)
              .WithMany(u => u.Tasks)
              .HasForeignKey(t => t.UserId);
        });
        }
    }
}