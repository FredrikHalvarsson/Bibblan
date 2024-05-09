using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibblan.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50, MinimumLength =2, ErrorMessage ="Name must be within 2 and 50 characters long")]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(50, MinimumLength =5, ErrorMessage ="Email must be within 5 and 50 characters long")]
        public string CustomerEmail { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Number must be within 3 and 20 characters long")]
        public string CustomerPhone { get; set; }

        [StringLength(50, MinimumLength =5, ErrorMessage ="Address must be within 5 and 50 characters long")]
        public string CustomerAddress { get; set; }

        public IEnumerable<BookCheckout>? BookCheckouts { get; set; } = null;
    }
}
