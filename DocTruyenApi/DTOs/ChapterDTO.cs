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

        public ChapterDTO()
        {
        }

        public ChapterDTO(int? chapterId, string? chapterName, int? chapterOrder)
        {
            ChapterId = chapterId;
            ChapterName = chapterName;
            ChapterOrder = chapterOrder;
        }

        public ChapterDTO(int? chapterId, string? chapterName, int? chapterOrder, string? content, int bookId)
        {
            ChapterId = chapterId;
            ChapterName = chapterName;
            ChapterOrder = chapterOrder;
            Content = content;
            BookId = bookId;
        }
    }
}
