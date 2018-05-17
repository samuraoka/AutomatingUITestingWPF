using System.ComponentModel;

namespace Northwind.UI.Common
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        //TODO

        public virtual string Caption
        {
            get { return string.Empty; }
        }

        //TODO

        public event PropertyChangedEventHandler PropertyChanged;

        //TODO
    }
}
