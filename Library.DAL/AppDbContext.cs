using Library.DAL.DataModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Library.DAL
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }

        public DbSet<Books> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Configure composite primary key for UserRole
        //    modelBuilder.Entity<UserRole>()
        //        .HasKey(ur => new { ur.UserId, ur.RoleId });

        //    // Configure composite primary key for RolePermission
        //    modelBuilder.Entity<RolePermission>()
        //        .HasKey(rp => new { rp.RoleId, rp.PermissionId });
        //}
    }
}
