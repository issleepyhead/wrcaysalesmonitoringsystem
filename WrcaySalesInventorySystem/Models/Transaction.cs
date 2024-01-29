using System.ComponentModel.DataAnnotations;

namespace WrcaySalesInventorySystem.Models
{
    internal class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
    }
}
