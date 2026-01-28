namespace Project.Models
{
    public class EmailUser
    {
            public int Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string EmailAddress { get; set; } = string.Empty;
            public string Company { get; set; } = string.Empty ;
            public int StorageGB { get; set; }
            public string Password { get; set; } = string.Empty;
        }

}
