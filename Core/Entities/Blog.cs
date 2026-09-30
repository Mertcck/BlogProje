namespace Core.Entities;

public class Blog : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int WriterId { get; set; }
    public Writer? Writer { get; set; }
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
