using MySqlConnector;
using Project.Models;

namespace Project.Services
{
    public class SoftwareService
    {
        private readonly string _connectionString =
            "server=localhost;database=subscriptionsystem;uid=root;pwd=;";

        public void AddSoftwareSubscription(SoftwareSubscription software)
        {
            using var con = new MySqlConnection(_connectionString);
            con.Open();

            string query = @"
                INSERT INTO softwares
                (SoftwareName, PlanType, Category, Email, Amount, SubscribedDate, RenewalDate)
                VALUES
                (@SoftwareName, @PlanType, @Category, @Email, @Amount, @SubscribedDate, @RenewalDate)";

            using var cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SoftwareName", software.SoftwareName);
            cmd.Parameters.AddWithValue("@PlanType", software.PlanType);
            cmd.Parameters.AddWithValue("@Category", software.Category);
            cmd.Parameters.AddWithValue("@Email", software.Email);
            cmd.Parameters.AddWithValue("@Amount", software.Amount);
            cmd.Parameters.AddWithValue("@SubscribedDate", software.SubscribedDate);
            cmd.Parameters.AddWithValue("@RenewalDate", software.RenewalDate);

            cmd.ExecuteNonQuery();
        }
    }
}
