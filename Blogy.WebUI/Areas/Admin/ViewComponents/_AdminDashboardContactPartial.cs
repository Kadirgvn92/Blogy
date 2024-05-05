using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.ViewComponents;

public class _AdminDashboardContactPartial : ViewComponent
{
    private readonly IContactService _contactService;

    public _AdminDashboardContactPartial(IContactService contactService)
    {
        _contactService = contactService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _contactService.TGetAll();
        return View(values);
    }
}
