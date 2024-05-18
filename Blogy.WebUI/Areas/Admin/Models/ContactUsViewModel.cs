using Blogy.EntityLayer;

namespace Blogy.WebUI.Areas.Admin.Models;

public class ContactUsViewModel
{
    public int ContactID { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Subject { get; set; }
    public string MessageBody { get; set; }
    public DateTime MessageDate { get; set; }
    public bool MessageStatus { get; set; }
    public Contact Contact { get; set; }
    public List<Contact> Contacts { get; set; }
    public int TotalContactUs { get; set; }
    public PageInfoModel PageInfo { get; set; }
}
