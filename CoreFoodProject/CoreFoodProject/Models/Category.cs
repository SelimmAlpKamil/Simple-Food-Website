using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreFoodProject.Models
{
	public class Category
	{
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName ="varchar(50)")]
        [Required(ErrorMessage ="Boş geçilemez")]
        [StringLength(50,ErrorMessage ="Lütfen 2-50 karakter arası veri giriş yapınız...",MinimumLength =2)]
        public string CategoryName { get; set; }
        [Required(ErrorMessage ="Boş geçilemez")]
		[Column(TypeName = "varchar(500)")]
        [StringLength(500,ErrorMessage ="Lütfen 5-500 karakter arası veri girişi yapınız...",MinimumLength =5)]

		public string CategoryDescription { get; set; }

        public bool CategoriyStatus { get; set; }   

        public List<Foot> Foots { get; set; }   
       
    }
}
