using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibblan.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be within 2 and 50 characters long")]
        public string BookName { get; set; }

        [Required]
        [StringLength(400, MinimumLength = 2, ErrorMessage = "Name must be within 2 and 400 characters long")]
        public string BookDescription { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be within 2 and 50 characters long")]
        public string BookAuthor { get; set; }

        public IEnumerable<BookCheckout>? BookCheckouts { get; set; } = null;
    }
}
