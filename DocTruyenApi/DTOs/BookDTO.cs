using DocTruyenApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocTruyenApi.DTOs
{
    public class BookDTO
    {
        public int? BookId { get; set; }
        public string? BookName { get; set; }
        public string? Description { get; set; }
        public string? PictureLink { get; set; }
        public int? WriterId { get; set; }
        public BookStatus? Status { get; set; }
        public List<GenreDTO> Genres { get; set; }
    }
}
