using Project.Models;

namespace Project.Services
{
    public class SoftwareService
    {
        public void AddSoftwareSubscription(SoftwareSubscription software)
        {
            using var db = new AppDbContext();
            db.Softwares.Add(software);
            db.SaveChanges();
        }
    }
}
