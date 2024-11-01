using DocTruyenApi.Models;

namespace DocTruyenApi.DTOs
{
    public class GenreDTO
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public GenreDTO(int genreId, string genreName)
        {
            GenreId = genreId;
            GenreName = genreName;
        }
    }
}
