using System.Threading.Tasks;
//using WrcaySalesInventorySystem.Data;

namespace WrcaySalesInventorySystem.Classs.Interface
{
    internal interface IDataCommand
    {
        bool Add();
        bool Delete();
        bool Update();
        bool Exists();

        // For excel functions
        bool IsValid();


    }
}
