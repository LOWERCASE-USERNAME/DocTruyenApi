using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocTruyenApi.Models
{
    public class ReadHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReadHistoryId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        [ForeignKey("Chapter")]
        public int? ChapterId { get; set; }
        public virtual Chapter Chapter { get; set; }
    }
}
