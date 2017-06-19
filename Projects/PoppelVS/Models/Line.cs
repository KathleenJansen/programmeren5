using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoppelProject.Models
{
    public class Line
    {
		public int Id { get; set; }
		public int HouseId { get; set; }

		public DateTime Date { get; set; }

		public int NumberOfEggs { get; set; }

		public int LitersOfWater { get; set; }

		public int AmountOfFood { get; set; }
	}
}
