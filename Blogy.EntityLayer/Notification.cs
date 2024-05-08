using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer;
public class Notification
{
    public int NotificationID { get; set; }
    public string Type { get; set; }
    public string Content { get; set; }
}
