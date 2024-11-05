using System.ComponentModel.DataAnnotations.Schema;

namespace DocTruyenApi.DTOs
{
    public class CommentDTO
    {
        public int? CommentId { get; set; }
        public string? Content { get; set; }
      
        //public int? UserId { get; set; }
        
        public int BookId { get; set; }
    }
}
