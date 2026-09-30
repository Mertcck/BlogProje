using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Writer> Writers => Set<Writer>();
    public DbSet<Comment> Comments => Set<Comment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().HasOne(x => x.Category).WithMany(x => x.Blogs).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Blog>().HasOne(x => x.Writer).WithMany(x => x.Blogs).HasForeignKey(x => x.WriterId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Comment>().HasOne(x => x.Blog).WithMany(x => x.Comments).HasForeignKey(x => x.BlogId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Teknoloji" }, new Category { Id = 2, Name = "Yaşam" }, new Category { Id = 3, Name = "Eğitim" });
        modelBuilder.Entity<Writer>().HasData(new Writer { Id = 1, FullName = "Site Editörü", Email = "editor@example.com" });
        modelBuilder.Entity<Blog>().HasData(
            new Blog { Id = 1, Title = "Katmanlı Mimariye Başlangıç", Content = "Bu örnek uygulama Core, Business, Data ve Web.UI katmanlarından oluşur. Her katman kendi sorumluluğunu üstlenir ve uygulamanın bakımı kolaylaşır.", CategoryId = 1, WriterId = 1, CreatedAt = new DateTime(2026, 9, 30, 9, 0, 0, DateTimeKind.Utc) },
            new Blog { Id = 2, Title = "Veriyle Çalışmak", Content = "Entity Framework Core ile uygulama verileri SQLite veritabanında kalıcı olarak saklanır. Blog yazıları, kategoriler, yazarlar ve yorumlar ilişkisel olarak yönetilir.", CategoryId = 1, WriterId = 1, CreatedAt = new DateTime(2026, 9, 29, 9, 0, 0, DateTimeKind.Utc) });
    }
}
