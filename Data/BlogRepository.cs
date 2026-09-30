using Core.Abstracts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class BlogRepository(BlogDbContext context) : IBlogRepository
{
    public async Task<IReadOnlyList<Blog>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await context.Blogs.AsNoTracking().Include(x => x.Category).Include(x => x.Writer).OrderByDescending(x => x.CreatedAt).ToListAsync(cancellationToken);

    public Task<Blog?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        context.Blogs.AsNoTracking().Include(x => x.Category).Include(x => x.Writer).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task AddAsync(Blog blog, CancellationToken cancellationToken = default)
    {
        await context.Blogs.AddAsync(blog, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
