using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrsEf {

	public class Product {

		public int Id { get; set; }

		[StringLength(30)]
		[Required]
		public string PartNumber { get; set; }

		[StringLength(30)]
		[Required]
		public string Name { get; set; }

		public double Price { get; set; }

		[StringLength(30)]
		[Required]
		public string Unit { get; set; }

		[StringLength(130)]
		public string PhotoPath { get; set; }

		public bool Active { get; set; } = true;

		public int VendorId { get; set; }
		public virtual Vendor Vendor { get; set; }

		public Product() { }
	}
}