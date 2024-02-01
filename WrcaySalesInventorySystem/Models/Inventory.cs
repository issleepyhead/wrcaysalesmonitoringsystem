using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Models
{
    public class Inventory : IDataCommand
    {
        public int InventoryID { get; set; }
        public int DeliveryID { get; set; }
        public int StockIn { get; set; }

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
