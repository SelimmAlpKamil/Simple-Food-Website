using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreFoodProject.Models
{
    public class Foot
    {
        [Key]
        public int FootId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Boş geçilemez")]
        [StringLength(50, ErrorMessage = "Lütfen 2-50 karakter arası veri giriniz...", MinimumLength = 2)]
        public string FootName { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required(ErrorMessage = "Boş geçilemez")]
        [StringLength(500, ErrorMessage = "Lütfen 5-500 karakter arası veri giriniz...", MinimumLength = 5)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        public double FootPrice { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        public string FootImageURl { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]

        public int FootStock { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
