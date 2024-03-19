namespace Blogy.WebUI.Models;

public class CreateUserViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    public string SuccessMessage { get; set; }
    public bool AcceptTerms { get; set; }
}
