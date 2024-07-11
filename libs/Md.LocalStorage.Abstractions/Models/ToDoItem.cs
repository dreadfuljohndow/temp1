namespace Md.LocalStorage.Abstractions.Models
{
    public class ToDoItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedDateTime { get; set; }

        public string? ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}