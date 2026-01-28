namespace Project.Models
{
    public class DomainSubscription
    {
        public int Id { get; set; }
        public string DomainName { get; set; } = string.Empty;
        public string Registrar { get; set; } = string.Empty ;

        public DateTime RegisteredDate { get; set; }
        public DateTime RenewalDate { get; set; }

        public string NameServer1 { get; set; } = string.Empty;
        public string NameServer2 { get; set; } = string.Empty;

        public decimal Amount { get; set; }
        public bool AutoRenew { get; set; }
    }
}
