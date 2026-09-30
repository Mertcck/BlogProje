using Core.Entities;

namespace Core.Abstracts;

public interface IBlogRepository
{
    Task<IReadOnlyList<Blog>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Blog?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(Blog blog, CancellationToken cancellationToken = default);
}
