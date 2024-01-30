using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Classs
{
    internal class DeleteCommand : IDataExecutor
    {

        private IDataCommand dataCommand;

        public DeleteCommand(IDataCommand dataCommand)
        {
            this.dataCommand = dataCommand;
        }

        public bool Execute()
        {
            return this.dataCommand.Delete();
        }
    }
}
