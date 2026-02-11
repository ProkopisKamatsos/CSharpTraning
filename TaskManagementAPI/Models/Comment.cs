using System;

namespace TaskManagementAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }                    // NOT NULL
        public int UserId { get; set; }                    // NOT NULL

        public string Content { get; set; } = null!;       // NOT NULL
        public DateTime CreatedAt { get; set; }            // default in DB
    }
}
