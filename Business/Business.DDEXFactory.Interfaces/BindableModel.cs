using Business.DDEXFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.DDEXFactory.Intefaces
{
    public class BindableModel : INotifyPropertyChanged, IBindableModel
    {
        private Dictionary<string, object> _properties = new Dictionary<string, object>();

        protected T Get<T>([CallerMemberName] string name = null)
        {
            object value = null;
            if (_properties.TryGetValue(name, out value))
                return value == null ? default(T) : (T)value;
            return default(T);
        }

        protected void Set<T>(T value, [CallerMemberName] string name = null)
        {
            if (Equals(value, Get<T>(name)))
                return;
            _properties[name] = value;
            OnPropertyChanged(name);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual bool IsValid(out string message)
        {
            message = "";
            bool isValid = true;
            List<PropertyInfo> props = GetType().GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(NotNullAttribute))).ToList();

            foreach (PropertyInfo pi in props)
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string) pi.GetValue(this);
                    if (value == null || value == "")
                    {
                        message = pi.Name + " cannot be empty";
                        isValid = false;
                        break;
                    }
                }
                else
                { 
                    if (Object.Equals(pi.GetValue(this), null))
                    {
                        message = pi.Name + " cannot be empty";
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }

        public virtual BindableModel Copy()
        {
            BindableModel ret = (BindableModel) Activator.CreateInstance(GetType());

            // shallow copy
            var properties = GetType().GetProperties().ToList();
            properties.ForEach(x => 
                {
                    if (x.CanWrite) x.SetValue(ret, x.GetValue(this));
                }
            );

            return ret;
        }

        public virtual void CopyFromSource(BindableModel source)
        {
            var properties = GetType().GetProperties().ToList();
            properties.ForEach(x =>
                {
                    if (x.CanWrite) x.SetValue(this, x.GetValue(source));
                }
            );
        }
    }
}
