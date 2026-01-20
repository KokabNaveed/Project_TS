using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class SoftwareEntity
    {
        [Key]
        public int Id { get; set; }

        public string SoftwareName { get; set; }
        public string PlanType { get; set; }
        public string Category { get; set; }

        public string Email { get; set; }

        public DateTime SubscribedDate { get; set; }
        public DateTime? RenewalDate { get; set; }

        public decimal Amount { get; set; }
    }
}
