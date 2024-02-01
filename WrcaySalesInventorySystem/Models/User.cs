using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Models
{
    public class User : IDataCommand
    {

        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Username must be 100 characters or less."), MinLength(6)]
        [DisplayName("Username")]
        [Column(TypeName = "VARCHAR")]
        public string? UserName { get; set; }

        [Required]
        [MaxLength(75)]
        [DisplayName("Password")]
        [Column( TypeName = "VARCHAR")]
        public string? Password { get; set; }

        [MaxLength(100, ErrorMessage = "First name must be 100 characters or less.")]
        [DisplayName("First Name")]
        [Column(TypeName = "VARCHAR")]
        public string? FirstName { get; set; }

        [MaxLength(100, ErrorMessage = "Last name must be 100 characters or less.")]
        [DisplayName("Last Name")]
        [Column(TypeName = "VARCHAR")]
        public string? LastName { get; set; }

        [MaxLength(150, ErrorMessage="Email must be 150 characters or less.")]
        [Column(TypeName ="VARCHAR")]
        public string? Email { get; set; }

        [DisplayName("Birth Date")]
        [Column(TypeName="DATE")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Role")]
        [DefaultValue("NULL")]
        public int RoleID { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role? Role {get; set;}

        public Task<bool> Add()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete()
        {
            throw new System.NotImplementedException();
        }

        public bool Exists()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsValid()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
