﻿using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UI;

public class _UIFooterPartial :ViewComponent
{
    private readonly IArticleService _articleService;

    public _UIFooterPartial(IArticleService articleService)
    {
        _articleService = articleService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _articleService.TGetAllArticles();
        return View(values);  
    }
}
