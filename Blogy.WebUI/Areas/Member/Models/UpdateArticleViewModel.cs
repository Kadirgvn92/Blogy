﻿namespace Blogy.WebUI.Areas.Member.Models;

public class UpdateArticleViewModel
{
    public int ArticleID { get; set; }
    public string Title { get; set; }
    public string FirstSection { get; set; }
    public string SecondSection { get; set; }
    public string? ThirdSection { get; set; }
    public string? FourthSection { get; set; }
    public string Description { get; set; }
    public string? CoverImageUrl { get; set; }
    public IFormFile Image { get; set; }
    public int WriterID { get; set; }
    public int CategoryID { get; set; }
}
