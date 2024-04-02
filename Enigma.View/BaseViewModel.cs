using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Enigma.View
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<string, object> _properties;

        public BaseViewModel()
        {
            _properties = new Dictionary<string, object>();
        }

        internal void Set<T>(T value, [CallerMemberName] string propertyName = null)
        {
            _properties[propertyName] = value;

        }

        internal T Get<T>([CallerMemberName] string propertyName = null)
        {
            if (_properties.TryGetValue(propertyName, out object value))
                return (T)value;
            return default(T);
        }

        public void Notify(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
