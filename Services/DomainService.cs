using MySqlConnector;
using Project.Models;

namespace Project.Services
{
    public class DomainService
    {
        private readonly string _connectionString =
            "server=localhost;database=subscriptionsystem;uid=root;pwd=;";

        public void AddDomain(DomainSubscription domain)
        {
            using var con = new MySqlConnection(_connectionString);
            con.Open();

            string query = @"
                INSERT INTO domains
                (DomainName, Registrar, Amount, RegisteredDate, RenewalDate,
                 NameServer1, NameServer2, AutoRenew)
                VALUES
                (@DomainName, @Registrar, @Amount, @RegisteredDate, @RenewalDate,
                 @NS1, @NS2, @AutoRenew)";

            using var cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@DomainName", domain.DomainName);
            cmd.Parameters.AddWithValue("@Registrar", domain.Registrar);
            cmd.Parameters.AddWithValue("@Amount", domain.Amount);
            cmd.Parameters.AddWithValue("@RegisteredDate", domain.RegisteredDate);
            cmd.Parameters.AddWithValue("@RenewalDate", domain.RenewalDate);
            cmd.Parameters.AddWithValue("@NS1", domain.NameServer1);
            cmd.Parameters.AddWithValue("@NS2", domain.NameServer2);
            cmd.Parameters.AddWithValue("@AutoRenew", domain.AutoRenew);

            cmd.ExecuteNonQuery();
        }
    }
}
