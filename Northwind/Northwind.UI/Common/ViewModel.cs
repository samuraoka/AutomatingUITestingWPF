using System.ComponentModel;

namespace Northwind.UI.Common
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected static readonly DialogService _dialogService = new DialogService();
        //TODO

        public virtual string Caption
        {
            get { return string.Empty; }
        }

        public virtual double Width
        {
            get { return 300; }
        }

        public virtual double Height
        {
            get { return 400; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //TODO

        public virtual void RefreshAll()
        {
        }
    }
}
