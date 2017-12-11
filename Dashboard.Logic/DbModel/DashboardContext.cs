using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Logic.DbModel
{
    public class DashboardContext : IdentityDbContext<ApplicationUser>
    {
        public DashboardContext(DbContextOptions<DashboardContext> options)
        : base(options)
        { }

        public DbSet<LogInfo> LogInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LogInfo>()
                .Property(b => b.PropertiesSerialized)
                .HasColumnName("Properties");
        }
    }
}
