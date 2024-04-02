using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Enigma.Engine.Models
{
    public class CoreModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<string, object> _properties;

        public CoreModel()
        {
            _properties = new Dictionary<string, object>();
        }

        protected void Set<T>(T value, [CallerMemberName] string propertyName = null)
        {
            _properties[propertyName] = value;

        }

        protected T Get<T>([CallerMemberName] string propertyName = null)
        {
            if (_properties.TryGetValue(propertyName, out object value))
                return (T)value;
            return default(T);
        }

        protected void Notify(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
