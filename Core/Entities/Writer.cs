namespace Core.Entities;

public class Writer : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}
