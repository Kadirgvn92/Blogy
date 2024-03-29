﻿using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework;
public class EfWriterDal : GenericRepository<Writer>, IWriterDal
{
    public EfWriterDal(BlogyDbContext db) : base(db)
    {
    }
}
