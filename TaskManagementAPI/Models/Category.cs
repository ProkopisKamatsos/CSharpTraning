namespace TaskManagementAPI.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;          // NOT NULL (unique in DB)
        public string? Color { get; set; }                 // NULL
        public string? Icon { get; set; }                  // NULL
    }
}
