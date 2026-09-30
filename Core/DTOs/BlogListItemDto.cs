namespace Core.DTOs;

public class BlogListItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ContentPreview { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string WriterName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
