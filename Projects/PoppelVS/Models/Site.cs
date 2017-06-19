using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoppelProject.Models
{
    public class Site
    {
		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<House> Houses { get; set; }
	}
}
