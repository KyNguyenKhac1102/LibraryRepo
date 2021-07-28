
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]


        public Book Book { get; set; }
    }
}