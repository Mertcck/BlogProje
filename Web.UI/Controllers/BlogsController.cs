using Core.Abstracts;
using Core.DTOs;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.UI.Models;

namespace Web.UI.Controllers;

public class BlogsController(IBlogService blogService, BlogDbContext database) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken) => View(await blogService.GetAllAsync(cancellationToken));

    [HttpGet]
    public async Task<IActionResult> Create(CancellationToken cancellationToken) => View(await BuildModelAsync(new CreateBlogDto(), cancellationToken));

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BlogCreateViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = await GetCategoriesAsync(cancellationToken);
            return View(model);
        }

        await blogService.CreateAsync(model.Blog, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    private async Task<BlogCreateViewModel> BuildModelAsync(CreateBlogDto dto, CancellationToken cancellationToken) => new()
    {
        Blog = dto,
        Categories = await GetCategoriesAsync(cancellationToken)
    };

    private async Task<IEnumerable<SelectListItem>> GetCategoriesAsync(CancellationToken cancellationToken) =>
        await database.Categories.AsNoTracking().OrderBy(x => x.Name).Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToListAsync(cancellationToken);
}
