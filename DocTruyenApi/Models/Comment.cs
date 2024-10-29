using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace DocTruyenApi.Models
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public string Content { get; set; }
        [ForeignKey("User")]
        public int UserId { get;set; }
        [ForeignKey("Book")]
        public int BookId { get;set; }
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
