using System.ComponentModel;

namespace WrcaySalesInventorySystem.ViewModel
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void Changed(string property_name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property_name));
            }
        }
    }
}
