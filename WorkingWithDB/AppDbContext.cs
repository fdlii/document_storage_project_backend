using Microsoft.EntityFrameworkCore;
using WorkingWithDB.Configurations;
using WorkingWithDB.Models;

namespace WorkingWithDB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<FolderEntity> Folders { get; set; }
        public DbSet<FileEntity> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FolderConfiguration());
            modelBuilder.ApplyConfiguration(new FileConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
