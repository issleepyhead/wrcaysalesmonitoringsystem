using System.Threading.Tasks;
//using WrcaySalesInventorySystem.Data;

namespace WrcaySalesInventorySystem.Classs.Interface
{
    internal interface IDataCommand
    {
        Task<bool> Add();
        Task<bool> Delete();
        Task<bool> Update();
        bool Exists();

        // For excel functions
        Task<bool> IsValid();


    }
}
