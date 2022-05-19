using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menuu.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Type the name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type the last name")]
        [StringLength(50)]
        public string LastName  { get; set; }

        [Required(ErrorMessage = "Type the address")]
        [StringLength(100)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Type the zip code")]
        [StringLength(10, MinimumLength = 8)]
        public string ZipCode { get; set; }

        [StringLength(10)]
        public string State { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Type the phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Type the email address")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])", ErrorMessage="The email address isn't in a correct format")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name="Order Total")]
        public decimal OrderTotal { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Order Items")]
        public int OrderItemsSum { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime OrderSent { get; set; }


        [Display(Name = "Order Delivery Date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime OrderDelivered { get; set; }

        public List<OrderDetail> OrderItems { get; set; }
    }
}
