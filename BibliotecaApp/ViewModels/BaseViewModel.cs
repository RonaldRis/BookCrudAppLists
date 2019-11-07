
namespace BibliotecaApp.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    public class BaseViewModel : INotifyPropertyChanged
    {
        //Para modificar los campos que usen binding context entiempo de ejecucion con los set
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
