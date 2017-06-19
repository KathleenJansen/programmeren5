using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoppelProject.Models;

namespace PoppelProject.Models
{
	public class appDbContext : DbContext
	{
		public appDbContext(DbContextOptions<appDbContext> options)
		: base(options)
		{ }

		public DbSet<PoppelProject.Models.House> House { get; set; }

		public DbSet<PoppelProject.Models.Line> Line { get; set; }

		public DbSet<PoppelProject.Models.Round> Round { get; set; }

		public DbSet<PoppelProject.Models.Site> Site { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<House>().HasKey(m => m.Id);
			builder.Entity<Line>().HasKey(m => m.Id);
			builder.Entity<Round>().HasKey(m => m.Id);
			builder.Entity<Site>().HasKey(m => m.Id);
		}
	}
}
