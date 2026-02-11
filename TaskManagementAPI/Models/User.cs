namespace TaskManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;      // NOT NULL
        public string Email { get; set; } = null!;         // NOT NULL
        public string PasswordHash { get; set; } = null!;  // NOT NULL

        public string? FirstName { get; set; }             // NULL
        public string? LastName { get; set; }              // NULL

        public DateTime CreatedAt { get; set; }            // default in DB
        public DateTime UpdatedAt { get; set; }            // default in DB
        public bool IsActive { get; set; }                 // default in DB
    }
}
