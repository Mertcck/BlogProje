namespace Core.Entities;

public class Comment : BaseEntity
{
    public string AuthorName { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int BlogId { get; set; }
    public Blog? Blog { get; set; }
}
