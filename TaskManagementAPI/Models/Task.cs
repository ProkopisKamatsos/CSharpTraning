using System;

namespace TaskManagementAPI.Models
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }

    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;         // NOT NULL
        public string? Description { get; set; }           // NULL

        public TaskStatus Status { get; set; }             // NOT NULL (stored as string in DB)
        public int Priority { get; set; }                  // NOT NULL
        public int UserId { get; set; }                    // NOT NULL

        public DateTime? DueDate { get; set; }             // NULL
        public DateTime CreatedAt { get; set; }            // default in DB
        public DateTime UpdatedAt { get; set; }            // default in DB
        public DateTime? CompletedAt { get; set; }         // NULL
    }
}
