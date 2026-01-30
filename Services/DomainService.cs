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

        public void UpdateDomain(DomainSubscription domain)
        {
            using var db = new AppDbContext();
            var existing = db.Domains.FirstOrDefault(d => d.Id == domain.Id);
            if (existing == null) return;

            existing.DomainName = domain.DomainName;
            existing.Registrar = domain.Registrar;
            existing.NameServer1 = domain.NameServer1;
            existing.NameServer2 = domain.NameServer2;
            existing.Amount = domain.Amount;
            existing.RegisteredDate = domain.RegisteredDate;
            existing.RenewalDate = domain.RenewalDate;
            existing.AutoRenew = domain.AutoRenew;

            db.SaveChanges();
        }

        public void RemoveDomain(DomainSubscription domain)
        {
            using var db = new AppDbContext();
            var existing = db.Domains.FirstOrDefault(d => d.Id == domain.Id);
            if (existing != null)
            {
                db.Domains.Remove(existing);
                db.SaveChanges();
            }
        }
    }
}
