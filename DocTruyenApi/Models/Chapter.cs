
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocTruyenApi.Models
{
    public class Chapter
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChapterId { get; set; }
        public string ChapterName { get; set; }
        public int ChapterOrder { get; set; }
        public string Content { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}