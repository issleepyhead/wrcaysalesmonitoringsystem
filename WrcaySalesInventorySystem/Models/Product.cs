﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Models
{
    public class Product : IDataCommand
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Product Name must be 50 characters or less.")]
        [Column(TypeName = "VARCHAR")]
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [DisplayName("Product Description")]
        [MaxLength(300, ErrorMessage = "Product Descriptio must be 50 characters or less.")]
        public string? ProductDescription { get; set; }

        [Required]
        [DisplayName("Price")]
        public double ProductPrice { get; set; }

        [Required]
        [DisplayName("Cost")]
        public double ProductCost { get; set; }

        [DefaultValue("NULL")]
        public int SupplierID { get; set; }

        [DefaultValue("NULL")]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category? Category { get; set; } = null;

        [ForeignKey("SupplierID")]
        public virtual Supplier? Supplier { get; set; } = null;

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

