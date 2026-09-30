using Core.DTOs;

namespace Core.Abstracts;

public interface IBlogService
{
    Task<IReadOnlyList<BlogListItemDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<BlogListItemDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<int> CreateAsync(CreateBlogDto dto, CancellationToken cancellationToken = default);
}
