﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsEf {

	public class PurchaseRequestLineitem {
		public int Id { get; set; }
		public int PurchaseRequestId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }

		public virtual PurchaseRequest PurchaseRequest { get; set; }
		public virtual Product Product { get; set; }

		public PurchaseRequestLineitem() { }
	}
}
