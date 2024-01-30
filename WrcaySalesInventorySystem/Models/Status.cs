﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Models
{
    internal class Status : IDataCommand
    {
        [Key]
        public int StatusID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Status name must be 50 characters or less.")]
        [DisplayName("Status Name")]
        [Column(TypeName = "VARCHAR")]
        public string? StatusName { get; set; }

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
