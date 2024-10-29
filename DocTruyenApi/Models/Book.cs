using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocTruyenApi.Models
{
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [MaxLength(255)]
        public string BookName { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime UploadTime { get; set; }
        public string PictureLink { get; set; }
        public BookStatus Status { get; set; }
        public virtual IEnumerable<Genre> Genres { get; set; }
        public virtual IEnumerable<Author> Authors { get;set; }
        public virtual IEnumerable<Chapter> Chapters { get; set; }
    }

    public enum BookStatus
    {
        Unknown = 0,
        Published = 1,
        Pausing = 2,
        Cancelled = 3
    }
}