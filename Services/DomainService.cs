using Project.Models;

namespace Project.Services
{
    public class DomainService
    {
        public List<DomainSubscription> GetAll()
        {
            using var db = new AppDbContext();
            return db.Domains.ToList();
        }
        public void AddDomain(DomainSubscription domain)
        {
            using var db = new AppDbContext();
            db.Domains.Add(domain);
            db.SaveChanges();
        }
        public void RemoveDomain(DomainSubscription domain)
        {
            using var db = new AppDbContext();
            db.Domains.Remove(domain);
            db.SaveChanges();
        }
        public void  UpdateDomain(DomainSubscription domain)
        {
            using var db = new AppDbContext();
            db.Domains.Update(domain);
            db.SaveChanges();
        }

    }
}
