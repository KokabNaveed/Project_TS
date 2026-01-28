using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class SoftwareSubscription
    {
        [Key]
        public int Id { get; set; }

        public string SoftwareName { get; set; } = string.Empty;
        public string PlanType { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;  

        public DateTime SubscribedDate { get; set; }
        public DateTime? RenewalDate { get; set; }

        public decimal Amount { get; set; }
    }
}
