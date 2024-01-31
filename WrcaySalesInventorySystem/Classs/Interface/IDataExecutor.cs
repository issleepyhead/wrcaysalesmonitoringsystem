using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrcaySalesInventorySystem.Classs.Interface
{
    internal interface IDataExecutor
    {
        Task<bool> Execute();
    }
}
