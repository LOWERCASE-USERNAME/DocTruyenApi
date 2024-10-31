using DocTruyenApi.Models;

namespace DocTruyenApi.DTOs
{
    public class ResponseBookDTO
    {
        public int? BookId { get; set; }
        public string? BookName { get; set; }
        public string? Description { get; set; }
        public DateTime? UploadTime { get; set; }
        public string? PictureLink { get; set; }
        public BookStatus? Status { get; set; }
        public IEnumerable<ChapterDTO>? Chapters { get; set; }
        public IEnumerable<GenreDTO>? Genres { get; set; }
        public IEnumerable<AuthorDTO>? Authors { get; set; }
    }
}
