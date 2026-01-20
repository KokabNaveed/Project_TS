using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class EmailEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;


        public string LastName { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string Company { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int StorageGB { get; set; }
    }
}
