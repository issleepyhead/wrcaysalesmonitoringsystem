using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrcaySalesInventorySystem.Models
{
    internal class Status
    {
        [Key]
        public int StatusID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Status name must be 50 characters or less.")]
        [DisplayName("Status Name")]
        public string? StatusName { get; set; }
    }
}
