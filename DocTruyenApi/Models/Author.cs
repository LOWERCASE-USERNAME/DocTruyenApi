using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocTruyenApi.Models
{
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        [MaxLength(255)]
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Book> Books { get;set; }
    }
}