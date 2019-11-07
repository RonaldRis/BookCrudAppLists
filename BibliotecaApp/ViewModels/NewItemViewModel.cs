using BibliotecaApp.Models;
using BibliotecaApp.Repository;
using BibliotecaApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BibliotecaApp.ViewModels
{
    public class NewItemViewModel :BaseViewModel
    {
        #region Atributos 
        /// <summary>
        /// EStas me sirven para manejar mejor las propiedades publicas y así gestionar cambios de valores
        /// </summary>
        private Book _BookCurrent;
        private string _Update_Create;
        private bool _isNew;
        #endregion

        #region Propiedades
        public string Update_Create
        {
            get { return _Update_Create; }
            set
            {
                if (_Update_Create != value)
                {
                    _Update_Create = value;
                    OnPropertyChanged("Update_Create");
                }
            }
        }
        public Book BookCurrent
        {
            get { return _BookCurrent; }
            set
            {
                if (_BookCurrent != value)
                {
                    _BookCurrent = value;
                    OnPropertyChanged("BookCurrent");
                }
            }
        }
        #endregion

        #region Constructor
        public NewItemViewModel(bool isNew,Book libro)
        {
            //isNew Indica por donde entro a esta page si por el boton de agregar unm nuevo registro o por medio de seleccionar un dato
            _isNew = isNew;
            if (isNew)
            {
                Update_Create = "Agregar";
            }
            else
            {
                Update_Create = "Actualizar";
            }
            BookCurrent = libro;
        }
        #endregion

        #region COMANDOS
        /// <summary>
        /// Son los que llaman a los botones que tengo en XAML del view y ejecutan las siguiente funciones
        /// </summary>
        public ICommand CreateOrUdateCommand { get { return new RelayCommand(CreateOrUdate); } }
        public ICommand EliminarCommand { get { return new RelayCommand(Eliminar); } }
        #endregion

        #region Metodos
        /// <summary>
        /// actualiza o elimina los datos segun corresponda
        /// </summary>
        private void CreateOrUdate()
        {
            RBook Repository = new RBook();
            if (_isNew)
            {
                if (Repository.Create(this.BookCurrent))
                {
                    App.Current.MainPage = new NavigationPage(new MainPage());
                    return;
                }
            }
            else
            {
                if (Repository.Update(BookCurrent.ID, BookCurrent))
                {
                    App.Current.MainPage = new NavigationPage(new MainPage());
                    return;
                }
            }
        }

        //Boton que elimina el registro que se mando a esta page
        private void Eliminar()
        {
            RBook Repository = new RBook();
            if (Repository.Delete(BookCurrent.ID))
            {
                App.Current.MainPage = new NavigationPage(new MainPage());
                return;
            }
        }
        #endregion

    }
}
