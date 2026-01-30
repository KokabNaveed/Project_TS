using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Services
{
    public class HomeService    {

            private readonly AppDbContext _db;

            public HomeService()
            {
                _db = new AppDbContext();
            }

            // 🔹 TOTAL COUNTS
            public int GetTotalEmails()
            {
                return _db.EmailUsers.Count();
            }

            public int GetTotalSoftware()
            {
                return _db.Softwares.Count();
            }

            public int GetTotalDomains()
            {
                return _db.Domains.Count();
            }

            // 🔹 SOFTWARE EXPIRING (MONTH / YEAR)
            public List<ExpiringItem> GetExpiringSoftware(DateTime limit)
            {
                return _db.Softwares
                    .Where(s =>
                        s.RenewalDate != null &&
                        s.RenewalDate <= limit)
                    .Select(s => new ExpiringItem
                    {
                        DisplayName = s.SoftwareName,
                        RenewalDate = s.RenewalDate.Value
                    })
                    .OrderBy(s => s.RenewalDate)
                    .ToList();
            }

            // 🔹 DOMAIN EXPIRING (MONTH / YEAR)
            public List<ExpiringItem> GetExpiringDomains(DateTime limit)
            {
                return _db.Domains
                    .Where(d => d.RenewalDate <= limit)
                    .Select(d => new ExpiringItem
                    {
                        DisplayName = d.DomainName,
                        RenewalDate = d.RenewalDate
                    })
                    .OrderBy(d => d.RenewalDate)
                    .ToList();
            }
        }
    }
