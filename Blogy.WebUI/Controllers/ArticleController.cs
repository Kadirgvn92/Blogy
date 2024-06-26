﻿using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers;
[AllowAnonymous]
public class ArticleController : Controller
{
	private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    public IActionResult Index(int id)
	{
        var values = _articleService.TGetArticle(id);
		return View(values);
	}
}
