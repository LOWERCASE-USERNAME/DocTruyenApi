using DocTruyenApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocTruyenApi.DTOs
{
    public class ChapterDTO
    {
        public int? ChapterId { get; set; }
        public string? ChapterName { get; set; }
        public int? ChapterOrder { get; set; }
        public string? Content { get; set; }
        public int BookId { get; set; }
    }
}
