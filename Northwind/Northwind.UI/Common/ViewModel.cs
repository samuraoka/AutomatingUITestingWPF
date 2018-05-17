using System;
using System.ComponentModel;

namespace Northwind.UI.Common
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected static readonly DialogService _dialogService = new DialogService();
        private bool? _dialogResult;

        public bool? DialogResult
        {
            get { return _dialogResult; }
            protected set
            {
                _dialogResult = value;
                Notify();
            }
        }

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


        private void Notify()
        {
            //TODO
            throw new NotImplementedException();
        }

        //TODO

        public virtual void RefreshAll()
        {
        }
    }
}
