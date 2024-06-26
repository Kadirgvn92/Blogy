﻿using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer;
using Blogy.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class WriterController : Controller
{
    private readonly IWriterService _writerService;
    private readonly UserManager<AppUser> _userManager;

	public WriterController(IWriterService writerService, UserManager<AppUser> userManager)
	{
		_writerService = writerService;
		_userManager = userManager;
	}
	public string GenerateName()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        Random random = new Random();
        char[] stringChars = new char[6];

        for (int i = 0; i < 6; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(stringChars);
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult GetWriter()
    {
        // Comment nesnelerini al
        var comments = _writerService.TGetAll().Where(x => x.IsDeleted == false && x.Name != "Admin");
        
        // Comment nesnelerini JSON formatına dönüştür
        var jsonComments = JsonConvert.SerializeObject(comments);
        // JSON formatındaki Comment nesnelerini View'e gönder
        return Content(jsonComments, "application/json");
    }
    public IActionResult DeleteWriter(int id)
    {
        _writerService.TDeleteWriter(id);
        return RedirectToAction("Index");
    }
    public IActionResult ActiveWriter(int id)
    {
        _writerService.TActiveWriter(id);
        return RedirectToAction("Index");
    }
    public IActionResult PassiveWriter(int id)
    {
        _writerService.TPassiveWriter(id);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult UpdateWriter(int id)
    {
        var values = _writerService.TGetByID(id);
        var model = new UpdateWriterViewModel
        {
            Description = values.Description,
            ImageUrl = values.ImageUrl,
            Name = values.Name,
            WriterID = values.WriterID,
        };
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateWriter(UpdateWriterViewModel model)
    {
        var values = _writerService.TGetByID(model.WriterID);

        if (model.Image != null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(model.Image.FileName);
            var imagename = GenerateName() + extension;
            var savelocation = resource + "/wwwroot/writerImages/" + imagename;
            var stream = new FileStream(savelocation, FileMode.Create);
            await model.Image.CopyToAsync(stream);
            model.ImageUrl = imagename;
        }
        else
        {
            model.ImageUrl = values.ImageUrl;
        }


        if (values != null)
        {
            values.WriterID = model.WriterID;
            values.Name = model.Name;
            values.Description = model.Description;
            values.ImageUrl = model.ImageUrl;

            _writerService.TUpdate(values);
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> CreateWriter()
    {
		var users = await _userManager.Users.ToListAsync(); // Tüm kullanıcıları al

		List<SelectListItem> userList = users.Select(u => new SelectListItem
		{
			Text = u.Name + " "+ u.Surname,
			Value = u.Id.ToString(),
		}).ToList();

		ViewBag.UserList = userList;
		return View();

    }
    [HttpPost]
    public async Task<IActionResult> CreateWriter(CreateWriterViewModel model)
    {
        using var context = new BlogyDbContext();
        var resource = Directory.GetCurrentDirectory();
        var extension = Path.GetExtension(model.Image.FileName);
        var imagename = GenerateName() + extension;
        var savelocation = resource + "/wwwroot/writerImages/" + imagename;
        var stream = new FileStream(savelocation, FileMode.Create);
        await model.Image.CopyToAsync(stream);
        model.ImageUrl = imagename;

        Writer writer = new Writer
        {
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            Name = model.Name,
            AppUserID = model.AppuserID,
        };

        var user = await _userManager.FindByIdAsync(model.AppuserID.ToString());
        user.IsAccepted = true;
        await _userManager.UpdateAsync(user);
        await context.SaveChangesAsync();
        _writerService.TInsert(writer);
        //burada isAccepted true yaptıramıyorum dbde
        
        return RedirectToAction("Index");
    }
}
