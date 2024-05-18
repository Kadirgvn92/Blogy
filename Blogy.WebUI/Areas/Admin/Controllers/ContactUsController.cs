using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Blogy.WebUI.Areas.Admin.Models;
using Blogy.WebUI.Areas.Member.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PageInfoModel = Blogy.WebUI.Areas.Admin.Models.PageInfoModel;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]

public class ContactUsController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IContactService _contactService;

    public ContactUsController(IContactService contactService, UserManager<AppUser> userManager)
    {
        _contactService = contactService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        const int pageSize = 10;
        var user = await _userManager.FindByNameAsync(User.Identity.Name);

        var model = new ContactUsViewModel
        {
            PageInfo = new PageInfoModel()
            {
                TotalItems = _contactService.TGetAll().Count(),
                CurrentPage = page,
                ItemsPerPage = pageSize,
            },
            Contacts = _contactService.TGetAll().OrderByDescending(x => x.MessageDate).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            TotalContactUs = _contactService.TGetAll().Count(),
        };
        return View(model);
    }
}
