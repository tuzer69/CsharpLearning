using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace HomeWork13.ViewModel
{
    public class Bindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string properyName = null)
        //{
        //    if (Equals(field, value)) return false;
        //    field = value;
        //    OnPropertyChanged(properyName);
        //    return true;
        //}
    }
}