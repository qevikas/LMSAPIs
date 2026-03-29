using LMSAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMSAPI.Context
{
    public class MyDbContext: DbContext
    {
        public MyDbContext() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<MainMenu> MainMenus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainMenu>().HasKey(x => x.ID);
        }

    }
}
