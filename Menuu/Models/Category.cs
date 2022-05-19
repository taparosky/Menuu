using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menuu.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(100, ErrorMessage ="Maximum length is 100 characters")]
        [Required(ErrorMessage ="Type the category name")]
        [Display(Name ="Name")]
        public string CategoryName { get; set; }

        [StringLength(200, ErrorMessage = "Maximum length is 200 characters")]
        [Required(ErrorMessage = "Type the category description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public List<Snack> Snacks { get; set; }

    }
}
