using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Classs
{
    internal class AddCommand : IDataExecutor
    {
        private readonly IDataCommand dataCommand;

        public AddCommand(IDataCommand dataCommand)
        {
            this.dataCommand = dataCommand;
        }

        public Task<bool> Execute()
        {
            return this.dataCommand.Add();
        }
    }
}
