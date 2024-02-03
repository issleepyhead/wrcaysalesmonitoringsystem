using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
    }
}
