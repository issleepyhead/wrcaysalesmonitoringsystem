using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WrcaySalesInventorySystem.Models
{
    internal class User
    {

        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage ="Username must be 100 characters or less."), MinLength(6)]
        [DisplayName("Username")]
        public string? UserName { get; set; }

        [Required]
        [MaxLength(75)]
        [DisplayName("Password")]
        public string? Password { get; set; }

        [MaxLength(100, ErrorMessage ="First name must be 100 characters or less.")]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [MaxLength(100, ErrorMessage ="Last name must be 100 characters or less.")]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        
        public string? Email { get; set; }

        [DisplayName("Birth Date")]
        public DateOnly BirthDate { get; set; }


    }
}
