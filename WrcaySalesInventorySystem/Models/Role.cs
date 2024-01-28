using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WrcaySalesInventorySystem.Models
{
    internal class Role
    {
        [Key]
        public int RoleID  { get; set; }

        [Required]
        [DisplayName("Role")]
        public string? RoleName { get; set; }
    }
}
