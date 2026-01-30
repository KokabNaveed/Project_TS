using Project.Models;

namespace Project.Services
{
    public class SoftwareService
    {
        public List<SoftwareSubscription> GetAll()
        {
            using var db = new AppDbContext();
            return db.Softwares.ToList();
        }

        public void AddSoftwareSubscription(SoftwareSubscription software)
        {
            using var db = new AppDbContext();
            db.Softwares.Add(software);
            db.SaveChanges();
        }

        public void UpdateSoftwareSubscription(SoftwareSubscription software)
        {
            using var db = new AppDbContext();

            var existing = db.Softwares.FirstOrDefault(s => s.Id == software.Id);
            if (existing == null) return;

            existing.SoftwareName = software.SoftwareName;
            existing.PlanType = software.PlanType;
            existing.Category = software.Category;
            existing.Amount = software.Amount;
            existing.Email = software.Email;
            existing.RenewalDate = software.RenewalDate;
            existing.SubscribedDate = software.SubscribedDate;

            db.SaveChanges();
        }

        public void RemoveSoftwareSubscription(SoftwareSubscription software)
        {
            using var db = new AppDbContext();

            var existing = db.Softwares.FirstOrDefault(s => s.Id == software.Id);
            if (existing != null)
            {
                db.Softwares.Remove(existing);
                db.SaveChanges();
            }
        }
    }
}
