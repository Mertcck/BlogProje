using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class CreateBlogDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public int WriterId { get; set; }
}
