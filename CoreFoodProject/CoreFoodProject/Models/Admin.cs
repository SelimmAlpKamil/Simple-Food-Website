using System.ComponentModel.DataAnnotations;

namespace CoreFoodProject.Models
{
	public class Admin
	{
		[Key]
        public int AdminId { get; set; }

        [StringLength(20,ErrorMessage ="2-20 karakter arası veri girilebilir", MinimumLength =2)]
        [Required(ErrorMessage ="Boş geçilemez")]
        public string AdminUserName { get; set; }

		[StringLength(20, ErrorMessage = "2-20 karakter arası veri girilebilir", MinimumLength = 2)]
		[Required(ErrorMessage = "Boş geçilemez")]
		public string AdminPassword { get; set; }

		[StringLength(1)]
		[Required(ErrorMessage = "Boş geçilemez")]
		public string AdminRole { get; set; }
        
    }
}
