using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WrcaySalesInventorySystem.Models
{
    internal class Role
    {
        [Key]
        public int RoleID  { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        [DisplayName("Role")]
        public string? RoleName { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
