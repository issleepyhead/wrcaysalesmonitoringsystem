using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelUser : ViewModelBase, IDataCommand
    {
        public bool Exists()
        {
            throw new NotImplementedException();
        }

        bool IDataCommand.Add()
        {
            throw new NotImplementedException();
        }

        bool IDataCommand.Delete()
        {
            throw new NotImplementedException();
        }

        bool IDataCommand.IsValid()
        {
            throw new NotImplementedException();
        }

        bool IDataCommand.Update()
        {
            throw new NotImplementedException();
        }
    }
}
