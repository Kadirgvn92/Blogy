using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Blogy.WebUI.Areas.Member.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json;
using RestSharp;

namespace Blogy.WebUI.Areas.Member.Controllers;

[Area("Member")]
[Route("Member/[controller]/[action]/{id?}")]
public class DashboardController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IWriterService _writerService;
    private readonly IArticleService _articleService;
    private readonly ICommentService _commentService;

    public DashboardController(UserManager<AppUser> userManager, IWriterService writerService, IArticleService articleService, ICommentService commentService)
    {
        _userManager = userManager;
        _writerService = writerService;
        _articleService = articleService;
        _commentService = commentService;
    }

    public async Task<IActionResult> Index()
    {
        var client = new RestClient("https://api.collectapi.com/weather/getWeather?data.lang=tr&data.city=bursa");
        var request = new RestRequest(RestSharp.Method.GET);
        request.AddHeader("authorization", "apikey 3vLvr8BLRuJZH5KJDssMMM:3s0zddCcs13UHM3tSE1TPp");
        request.AddHeader("content-type", "application/json");
        IRestResponse response = client.Execute(request);
        if (response.IsSuccessful)
        {
            var responseContent = JsonConvert.DeserializeObject<dynamic>(response.Content);
            var weatherList = new List<WeatherViewModel>();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var writer = _writerService.TGetWriter(user.Id);
            var count = _articleService.TGetAllArticles().Where(x => x.WriterID == writer.WriterID).Count();
            var articles = _articleService.TGetAllArticles().Where(x => x.WriterID == writer.WriterID);
            var comments = _commentService.TGetAll().Where(x => x.CommentStatus == "Onaylandı");

            var articleIds = articles.Select(a => a.ArticleID).ToList();

            // Comments tablosundaki articleID'leri makalelerin articleID'leri ile karşılaştırarak eşleşmeleri bulun
            var matchingCommentsCount = comments.Count(c => articleIds.Contains(c.ArticleID));

            var matchingComments = comments.Where(c => articleIds.Contains(c.ArticleID)).ToList();
            ViewBag.Comments = matchingCommentsCount;
            ViewBag.Count = count;
            ViewBag.Writer = writer.Name;
            ViewBag.Image = writer.ImageUrl;


            foreach (var json in responseContent.result)
            {
                var model = new WeatherViewModel
                {
                    Date = json.date,
                    Day = json.day,
                    Degree = json.degree,
                    Description = json.description,
                    Humidity = json.humidity,
                    Icon = json.icon,
                    Max = json.max,
                    Min = json.min,
                    Night = json.night,
                    Status = json.status,
                    Comments = matchingComments,
                };

                weatherList.Add(model);
            }

            return View(weatherList);
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> GetComments()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var writer = _writerService.TGetWriter(user.Id);
        var articles = _articleService.TGetAllArticles().Where(x => x.WriterID == writer.WriterID);
        var comments = _commentService.TGetCommentsWithArticles();

        var articleIds = articles.Select(a => a.ArticleID).ToList();
        var matchingComments = comments
       .Where(c => articleIds.Contains(c.ArticleID))
       .Select(c => new {
           ArticleTitle = c.Article.Title,
           FullName = c.FullName, 
           Content = c.Content,
           Email = c.Email, 
           CommentStatus = c.CommentStatus
       })
       .ToList();

        return Json(matchingComments);
    }
}
