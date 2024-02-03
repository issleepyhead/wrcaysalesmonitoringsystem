using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Models
{
    public class Role
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
