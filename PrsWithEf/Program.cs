using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrsEf;

namespace PrsWithEf {
	class Program {

		private static PrsDbContext db = new PrsDbContext();

		static void Main(string[] args) {

			var pEchoDot = new Product {
				Name = "Echo Dot",
				PartNumber = "EDOT",
				Price = 39.99,
				Unit = "Each",
				PhotoPath = null,
				VendorId = 1,
				Vendor = null
			};
			db.Products.Add(pEchoDot);
			db.SaveChanges();

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
			User addedUser = db.Users.Add(adduser);
			db.SaveChanges();

			db.Users.Remove(addedUser);
			db.SaveChanges();

			User u1 = db.Users.SingleOrDefault(u => u.Email == "gpdoud@gmail.com");
			u1.IsAdmin = true;
			db.SaveChanges();
		}
	}
}
