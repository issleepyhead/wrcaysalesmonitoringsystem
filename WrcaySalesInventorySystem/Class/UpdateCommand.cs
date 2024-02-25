using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Class
{
    public class UpdateCommand : IDataExecutor
    {
        private readonly IDataCommand _dataCommand;
        public UpdateCommand(IDataCommand dataCommand) => _dataCommand = dataCommand;
        public bool Execute()
        {
            return _dataCommand.Update();
        }
    }
}
