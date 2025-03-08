using System.ComponentModel.DataAnnotations;

namespace Urban.Eureka.API.Model
{
	public class User
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "User name is required.")]
		[StringLength(100, ErrorMessage = "User name cannot be longer than 100 characters.")]
		public string Name { get; set; }

		[StringLength(100, ErrorMessage = "User email cannot be longer than 100 characters.")]
		public string Email { get; set; }

		[StringLength(10, ErrorMessage = "User address cannot be longer than 10 characters.")]
		public string Telephone { get; set; }
	}
}
