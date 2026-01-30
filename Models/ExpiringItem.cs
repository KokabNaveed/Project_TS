using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class ExpiringItem
    {
        public string DisplayName { get; set; } = string.Empty;
        public DateTime RenewalDate { get; set; }

        public int DaysRemaining => Math.Max(0, (RenewalDate.Date - DateTime.Today).Days);

        public string Status
        {
            get
            {
                if (DaysRemaining <= 7) return "Expired";
                if (DaysRemaining <= 30) return "Soon To Expired";
                return "Abi time he";
            }
        }

    }
}
