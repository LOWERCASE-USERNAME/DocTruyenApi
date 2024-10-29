using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocTruyenApi.Models
{
    public class Account
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get;set; }
        public virtual Role Role { get; set; }
    }
}
