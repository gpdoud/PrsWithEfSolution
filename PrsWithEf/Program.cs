using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrsEf;

namespace PrsWithEf {
	class Program {

		private static PrsDbContext db = new PrsDbContext();

		void LinqExamples() {
			int[] nbrs = { 7,    7,   14,  13,  1,
							11,  12,  3,   20,  10,
							1,   10,  18,  17,  14,
							15,  6,   14,  20,  13 };
			var total = nbrs.Sum();
			total = nbrs.Where(i => i >= 10).Sum();
			total = nbrs.Where(i => i % 2 == 1).Sum();

			var min = nbrs.Min();
			var count = nbrs.Where(i => i > 5 && i <= 15).Count();

			var sortedNbrs = nbrs.OrderBy(i => i);
			sortedNbrs = nbrs.OrderByDescending(i => i);

			var subset = nbrs.Where(i => i % 3 == 0).ToArray();
			var subset2 = nbrs.Where(i => i % 3 == 0).ToList();
		}

		void CalcPrTotal() {

			var prid = db.PurchaseRequests.SingleOrDefault(p => p.Description == "Assignment PR").Id;
			var total = db.PurchaseRequestLineitems
				.Where(pl => pl.PurchaseRequestId == prid)
				.Sum(li => li.Product.Price * li.Quantity);
			var pr = db.PurchaseRequests.SingleOrDefault(fred => fred.Id == prid);
			pr.Total = total;
			db.SaveChanges();
		}

		static void Main(string[] args) {
			(new Program()).LinqExamples();
		}
		static void run() { 

			//var pEchoDot = new Product {
			//	Name = "Echo Dot",
			//	PartNumber = "EDOT",
			//	Price = 39.99,
			//	Unit = "Each",
			//	PhotoPath = null,
			//	VendorId = 1,
			//	Vendor = null
			//};
			//db.Products.Add(pEchoDot);
			//db.SaveChanges();

			var products = db.Products.ToList();
			var product = products[0];
			var vendorName = product.Vendor.Name;

			List<User> users = db.Users.ToList();
			User user = db.Users.Find(1);
			User nouser = db.Users.Find(111);

			User adduser = new User {
				Username = "gdoud",
				Password = "password",
				Firstname = "Greg",
				Lastname = "Doud",
				Phone = "513-555-1212",
				Email = "doud.gp@gmail.com",
				Active = true,
				IsAdmin = false,
				IsReviewer = false
			};
			//User addedUser = db.Users.Add(adduser);
			//db.SaveChanges();
			//db = new PrsDbContext();

			//var pr1 = new PurchaseRequest {
			//	Description = "First PR",
			//	Justification = "",
			//	DeliveryMode = "Pickup",
			//	UserId = db.Users.SingleOrDefault(u => u.Username == "gdoud").Id
			//};
			//db.PurchaseRequests.Add(pr1);
			//db.SaveChanges();


			var prli1 = new PurchaseRequestLineitem {
				PurchaseRequestId = db.PurchaseRequests.SingleOrDefault(pr => pr.Description == "First PR").Id,
				ProductId = db.Products.SingleOrDefault(p => p.PartNumber == "Echo").Id,
				Quantity = 1
			};
			db.PurchaseRequestLineitems.Add(prli1);
			db.SaveChanges();

		}
	}
}
