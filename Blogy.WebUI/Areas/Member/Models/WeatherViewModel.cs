using Blogy.EntityLayer;

namespace Blogy.WebUI.Areas.Member.Models;

public class WeatherViewModel
{
    public string Date { get; set; }
    public string Day { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Degree { get; set; }
    public string Min { get; set; }
    public string Max { get; set; }
    public string Night { get; set; }
    public string Humidity { get; set; }
    public List<WeatherViewModel> Weathers { get; set;}
    public List<Comment> Comments { get; set;}

}
