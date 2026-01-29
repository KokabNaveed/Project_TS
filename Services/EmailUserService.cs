using Project.Models;

namespace Project.Services
{
    public class EmailUserService
    {
        public bool EmailExists(string email)
        {
            using var db = new AppDbContext();

            return db.EmailUsers.Any(user => user.EmailAddress == email);
        }

        public void AddUser(EmailUser user)
        {
            using var db = new AppDbContext();
            db.EmailUsers.Add(user);
            db.SaveChanges();
        }
    }
}
