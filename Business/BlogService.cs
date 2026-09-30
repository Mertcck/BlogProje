using Core.Abstracts;
using Core.DTOs;
using Core.Entities;

namespace Business;

public class BlogService(IBlogRepository repository) : IBlogService
{
    public async Task<IReadOnlyList<BlogListItemDto>> GetAllAsync(CancellationToken cancellationToken = default) =>
        (await repository.GetAllAsync(cancellationToken)).Select(Map).ToList();

    public async Task<BlogListItemDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var blog = await repository.GetByIdAsync(id, cancellationToken);
        return blog is null ? null : Map(blog);
    }

    public async Task<int> CreateAsync(CreateBlogDto dto, CancellationToken cancellationToken = default)
    {
        var blog = new Blog { Title = dto.Title.Trim(), Content = dto.Content.Trim(), CategoryId = dto.CategoryId, WriterId = dto.WriterId };
        await repository.AddAsync(blog, cancellationToken);
        return blog.Id;
    }

    private static BlogListItemDto Map(Blog blog) => new()
    {
        Id = blog.Id,
        Title = blog.Title,
        ContentPreview = blog.Content.Length > 230 ? string.Concat(blog.Content.AsSpan(0, 230), "…") : blog.Content,
        CategoryName = blog.Category?.Name ?? string.Empty,
        WriterName = blog.Writer?.FullName ?? string.Empty,
        CreatedAt = blog.CreatedAt
    };
}
