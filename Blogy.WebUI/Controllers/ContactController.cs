using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Blogy.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Blogy.WebUI.Controllers;
[AllowAnonymous]
public class ContactController : Controller
{
    private readonly IContactService _contactService;

	public ContactController(IContactService contactService)
	{
		_contactService = contactService;
	}

	public IActionResult Index()
    {
        return View();
    }
	[HttpPost]
	public async Task<IActionResult> Index(SendMessageViewModel model)
	{
		if (ModelState.IsValid)
		{
			var contact = new Contact
			{
				Mail = model.Mail,
				MessageBody = model.MessageBody,
				MessageDate = DateTime.Now,
				MessageStatus = true,
				Name = model.Name,
				Subject = model.Subject
			};
			_contactService.TInsert(contact);
			await Task.Delay(2000);
			return RedirectToAction("Index", "Default");
		}
		return View();
	}
}
