using System.ComponentModel.DataAnnotations; /*this gives us data annotations used in outputting error messages to our form using semantic HTML markup.*/

namespace PortfolioASPdotNET.Models {
	public class ContactModels {
		[Required(ErrorMessage = "First Name is required")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Last Name is required")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "Email is required")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Comment is required")]
		public string Comment { get; set; }
	}
}