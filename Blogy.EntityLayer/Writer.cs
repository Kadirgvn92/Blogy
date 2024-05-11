using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer;
public class Writer
{
    public int WriterID { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public AppUser User { get; set; }
    public int AppUserID { get; set; }
    public List<Article> Articles { get; set; }
}
