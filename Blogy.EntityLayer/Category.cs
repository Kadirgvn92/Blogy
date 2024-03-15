﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer;
public class Category
{
    public int CategoryID { get; set; }
    public string? CategoryName { get; set; }
    public List<Article> Articles { get; set; }
}
