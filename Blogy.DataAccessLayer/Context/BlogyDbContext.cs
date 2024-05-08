using Blogy.EntityLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Context;
public class BlogyDbContext : IdentityDbContext<AppUser, AppRole, int>
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("server=DESKTOP-A6C5CRN\\MSSQLSERVER01;database=BlogyDb;Trusted_Connection=True;");
	}

	public DbSet<Article> Articles { get; set; }
	public DbSet<Contact> Contacts { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Comment> Comments { get; set; }
	public DbSet<Tag> Tags { get; set; }
	public DbSet<Writer> Writers { get; set; }
    public DbSet<Notification> Notifications { get; set; }

}
