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

        public void RemoveSoftwareSubscription(SoftwareSubscription software)
        {
            using var db = new AppDbContext();
            db.Softwares.Remove(software);
            db.SaveChanges();
        }

        public void UpdateSoftwareSubscription(SoftwareSubscription software)
        {
            using var db = new AppDbContext();
            db.Softwares.Update(software);
            db.SaveChanges();
        }
    }
}
