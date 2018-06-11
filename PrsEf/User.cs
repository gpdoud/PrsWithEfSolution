using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsEf {

	public class User {

		public int Id { get; set; }
		[Required]
		[StringLength(30)]
		[Index(IsUnique = true)]
		public string Username { get; set; }
		[Required]
		[StringLength(30)]
		public string Password { get; set; }
		[Required]
		[StringLength(30)]
		public string Firstname { get; set; }
		[Required]
		[StringLength(30)]
		public string Lastname { get; set; }
		[Required]
		[StringLength(12)]
		public string Phone { get; set; }
		[Required]
		[StringLength(255)]
		public string Email { get; set; }
		public bool IsReviewer { get; set; }
		public bool IsAdmin { get; set; }
		public bool Active { get; set; }

		public User() {

		}
	}
}
