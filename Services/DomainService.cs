using MySqlConnector;
using Project.Models;

namespace Project.Services
{
    public class DomainService
    {
        public void AddDomain(DomainSubscription domain)
        {
            using var db = new AppDbContext();
            db.Domains.Add(domain);
            db.SaveChanges();
        }
    }
}
