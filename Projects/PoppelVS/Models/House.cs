using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PoppelProject.Models
{
    public class House
    {
		public int Id { get; set; }

		public string Name { get; set; }

		public List<Round> Rounds { get; set; }

        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        public int SiteId { get; set; }

	}
}
