using DocTruyenApi.Models;
using System.ComponentModel.DataAnnotations;

namespace DocTruyenApi.DTOs
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; set; }

        public AuthorDTO(int authorId, string authorName, string description, string pictureLink)
        {
            AuthorId = authorId;
            AuthorName = authorName;
            Description = description;
            PictureLink = pictureLink;
        }
    }
}
