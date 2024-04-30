using Blogy.WebUI.Areas.Member.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json;
using RestSharp;

namespace Blogy.WebUI.Areas.Member.Controllers;

[Area("Member")]
[Route("Member/[controller]/[action]/{id?}")]
public class DashboardController : Controller
{
    public IActionResult Index()
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
                };

                weatherList.Add(model);
            }

            return View(weatherList);
        }
        return View();
    }
}
