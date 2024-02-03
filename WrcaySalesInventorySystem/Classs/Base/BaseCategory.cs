using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Classs.Base
{
    public class BaseCategory : IDataCommand
    {
        Task<bool> IDataCommand.Add()
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataCommand.Delete()
        {
            throw new NotImplementedException();
        }

        bool IDataCommand.Exists()
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataCommand.IsValid()
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataCommand.Update()
        {
            throw new NotImplementedException();
        }
    }
}
