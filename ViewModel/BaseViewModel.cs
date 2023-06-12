using System.Collections.Specialized;
using System.ComponentModel;

namespace NewsApplication.ViewModel {
    public class BaseViewModel : INotifyPropertyChanged {

        bool _isBusy;
        public bool IsBusy {
            get => _isBusy;
            set {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
