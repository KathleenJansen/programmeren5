using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoppelProject.Models
{
    public class Round
    {
		public int Id { get; set; }

		public List<Line> Lines { get; set; }

		public DateTime StartDate { get; set; }
	}
}
