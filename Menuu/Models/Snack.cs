using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menuu.Models
{
    [Table("Snacks")]
    public class Snack
    {
        [Key]
        public int SnackId { get; set; }

        [StringLength(80, MinimumLength = 10, ErrorMessage = "The {0} must have minimum {1} and maximum {2} characters")]
        [Required(ErrorMessage = "Type the snack name")]
        [Display(Name = "Name")]
        public string SnackName { get; set; }

        [StringLength(200, MinimumLength = 20, ErrorMessage = "The {0} must have minimum {1} and maximum {2} characters")]
        [Required(ErrorMessage = "Type the snack short description")]
        [Display(Name = "Snack short description")]
        public string ShortDescription { get; set; }

        [StringLength(200, MinimumLength = 20, ErrorMessage = "The {0} must have minimum {1} and maximum {2} characters")]
        [Required(ErrorMessage = "Type the snack long description")]
        [Display(Name = "Snack long description")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage ="Type the snack price")]
        [Display(Name ="Price")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1,999.99,ErrorMessage ="The price must be between 1 and 999.99")]
        public decimal Price { get; set; }

        [Display(Name ="Main image path")]
        [StringLength(200, ErrorMessage ="The {0} must have maximum {1} characters")]
        public string ImageUrl { get; set; }

        [Display(Name = "Thumbnail image path")]
        [StringLength(200, ErrorMessage = "The {0} must have maximum {1} characters")]
        public string ImageThumbUrl { get; set; }

        [Display(Name ="Favorite?")]
        public bool IsFavorite  { get; set; }

        [Display(Name = "Stock")]
        public bool InStock  { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


    }
}
