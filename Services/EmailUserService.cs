using Project.Models;

namespace Project.Services
{
    public class EmailUserService
    {
        public List<EmailUser> GetAll()
        {
            using var db = new AppDbContext();
            return db.EmailUsers.ToList();
        }
        public bool EmailExists(string email)
        {
            using var db = new AppDbContext();

            return db.EmailUsers.Any(user => user.EmailAddress == email);
        }

        public int GetUserIdByEmail(string email)
        {
            using var db = new AppDbContext();

            var user = db.EmailUsers.FirstOrDefault(u => u.EmailAddress == email);

            return user != null ? user.Id : -1; 
        }

        public void AddUser(EmailUser user)
        {
            using var db = new AppDbContext();
            db.EmailUsers.Add(user);
            db.SaveChanges();
        }

        public void RemoveUser(EmailUser user)
        {
            using var db = new AppDbContext();

            var existing = db.EmailUsers.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                db.EmailUsers.Remove(existing);
                db.SaveChanges();
            }
        }

        public void UpdateUser(EmailUser user)
        {
            using var db = new AppDbContext();

            var existing = db.EmailUsers.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                existing.EmailAddress = user.EmailAddress;
                existing.Password = user.Password;
                existing.FirstName = user.FirstName;
                existing.LastName = user.LastName;
                existing.StorageGB= user.StorageGB;
                existing.Company= user.Company;
                db.EmailUsers.Add(existing);

                db.SaveChanges();
            }
        }

    }
}
