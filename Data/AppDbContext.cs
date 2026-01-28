using Microsoft.EntityFrameworkCore;
using Project.Models;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql(
            "server=localhost;database=subscriptionsystem;user=root;password=;",
            ServerVersion.AutoDetect(
                "server=localhost;database=subscriptionsystem;user=root;password=;"
            )
        );
    }

    public DbSet<DomainSubscription> Domains { get; set; }
    public DbSet<SoftwareSubscription> Softwares { get; set; }
    public DbSet<EmailUser> EmailUsers { get; set; }
}
