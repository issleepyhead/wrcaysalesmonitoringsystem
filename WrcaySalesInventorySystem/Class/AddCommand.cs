using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Class
{
    public class AddCommand : IDataExecutor
    {
        private readonly IDataCommand _dataCommand;
        public AddCommand(IDataCommand command) => _dataCommand = command;
        public bool Execute()
        {
            return _dataCommand.Add();
        }
    }
}
