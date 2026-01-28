using MySqlConnector;
using Project.Models;

namespace Project.Services
{
    public class EmailUserService
    {
        private string connectionString =
            "server=localhost;database=subscriptionsystem;uid=root;pwd=;";

        public bool EmailExists(string email)
        {
            using var con = new MySqlConnection(connectionString);
            con.Open();

            var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM emailusers WHERE EmailAddress=@email", con);
            cmd.Parameters.AddWithValue("@email", email);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public void AddUser(EmailUser user)
        {
            using var con = new MySqlConnection(connectionString);
            con.Open();

            var cmd = new MySqlCommand(
                @"INSERT INTO emailusers
                  (FirstName, LastName, EmailAddress, Company, Password, StorageGB)
                  VALUES (@fn,@ln,@em,@co,@pw,@st)", con);

            cmd.Parameters.AddWithValue("@fn", user.FirstName);
            cmd.Parameters.AddWithValue("@ln", user.LastName);
            cmd.Parameters.AddWithValue("@em", user.EmailAddress);
            cmd.Parameters.AddWithValue("@co", user.Company);
            cmd.Parameters.AddWithValue("@pw", user.Password);
            cmd.Parameters.AddWithValue("@st", user.StorageGB);

            cmd.ExecuteNonQuery();
        }
    }
}
