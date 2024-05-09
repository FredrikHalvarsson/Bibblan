using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibblan.Models
{
    public class BookCheckout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookCheckoutId { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int FkCustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int FkBookId { get; set; }
        public Book? Book { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public bool IsReturned { get; set; } = false;

        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate => DateCreated.AddMonths(1);
    }
}
