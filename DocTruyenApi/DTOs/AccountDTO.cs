using DocTruyenApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocTruyenApi.DTOs
{
    public class AccountDTO
    {
        
        public int? AccountId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int? RoleId { get; set; } = 1;
    }
}
