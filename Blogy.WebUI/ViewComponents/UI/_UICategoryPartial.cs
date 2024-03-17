using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UI;

public class _UICategoryPartial :ViewComponent
{
    private readonly ICategoryService _categoryService;

    public _UICategoryPartial(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _categoryService.TGetCategories();
        return View(values);
    }
}
