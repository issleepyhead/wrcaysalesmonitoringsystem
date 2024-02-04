using System.Threading.Tasks;
using WrcaySalesInventorySystem.Data;

namespace WrcaySalesInventorySystem.Classs.Interface
{
    internal interface IDataCommand
    {
        Task<bool> Add(object data);
        Task<bool> Delete(object data);
        Task<bool> Update(object data);
        bool Exists(object data);

        // For excel functions
        Task<bool> IsValid(object data);


    }
}
