using Microsoft.EntityFrameworkCore;
using Project.Models;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql(
            "server=localhost;database=TS;user=root;password=;",
            new MySqlServerVersion(new Version(8,0,32))
        );
    }

    public DbSet<DomainSubscription> Domains { get; set; }
    public DbSet<SoftwareSubscription> Softwares { get; set; }
    public DbSet<EmailUser> EmailUsers { get; set; }
}
