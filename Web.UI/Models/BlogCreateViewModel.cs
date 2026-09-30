using Core.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.UI.Models;

public class BlogCreateViewModel
{
    public CreateBlogDto Blog { get; set; } = new();
    public IEnumerable<SelectListItem> Categories { get; set; } = [];
}
