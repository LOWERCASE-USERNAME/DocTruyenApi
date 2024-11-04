using DocTruyenApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocTruyenApi.DTOs
{
    public class UserDTO
    {
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public int? AccountId { get; set; }
    }
}
