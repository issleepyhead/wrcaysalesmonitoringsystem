using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Status name must be 50 characters or less.")]
        [DisplayName("Status Name")]
        [Column(TypeName = "VARCHAR")]
        public string? StatusName { get; set; }
    }
}
