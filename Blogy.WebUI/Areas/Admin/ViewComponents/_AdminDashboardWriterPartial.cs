using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.ViewComponents;

public class _AdminDashboardWriterPartial : ViewComponent
{
    private readonly IWriterService _writerService;

    public _AdminDashboardWriterPartial(IWriterService writerService)
    {
        _writerService = writerService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _writerService.TGetAll();
        return View(values);  
    }
}
