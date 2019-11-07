using BibliotecaApp.Models;
using BibliotecaApp.Repository;
using BibliotecaApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BibliotecaApp.ViewModels
{
    public class MainPageViewModel :BaseViewModel
    {
        #region Atributos 
        /// <summary>
        /// EStas me sirven para manejar mejor las propiedades publicas y así gestionar cambios de valores
        /// </summary>
        private Book _BookSelected;
        private ObservableCollection<Book> _Books;
        private bool _IsRefreshing;
        private RBook Repository;
        #endregion

        /// <summary>
        /// Estos son los valores que utilizo en el XAML por medio de Binding Context
        /// </summary>
        #region Propiedades
        public ObservableCollection<Book> Books
        {
            get { return _Books; }
            set
            {
                if (_Books != value)
                {
                    _Books = value;
                    OnPropertyChanged("Books");
                }
            }
        }
        //La propiedad de la rueda que da vueltas cuando se actualiza
        public bool IsRefreshing
        {
            get { return _IsRefreshing; }
            set
            {
                if (_IsRefreshing != value)
                {
                    _IsRefreshing = value;
                    OnPropertyChanged("IsRefreshing");
                }
            }
        }
        //El libro que selecciona cuando da click
        public Book BookSelected
        {
            get { return _BookSelected; }
            set
            {
                if (_BookSelected != value)
                {
                    _BookSelected = value;
                    OnPropertyChanged("BookSelected");
                    App.Current.MainPage.Navigation.PushAsync(new NewItemPage(false, BookSelected));
                }
            }
        }
        #endregion
        #region Construtor
        public MainPageViewModel()
        {
            //Inicializo los daytos que necesito
            this.BookSelected = null;
            Repository = new RBook();
            Books = new ObservableCollection<Book>();
            Refresh();
        }
        #endregion

        #region COMANDOS
        /// <summary>
        /// Son los que llaman a los botones que tengo en XAML del view y ejecutan las siguiente funciones
        /// </summary>
        public ICommand RefreshCommand { get { return new RelayCommand(Refresh); } }
        public ICommand newItemCommand { get { return new RelayCommand(newItem); } }
        #endregion

        #region Metodos
        private void newItem()
        {
            //Me manda a la siguiente pagina de cuando quiero agregar un nuevo registro
            Book Libro = new Book();
            App.Current.MainPage.Navigation.PushAsync(new NewItemPage(true, Libro));
        }
        private void Refresh()
        {

            //Cuando actualiza con el dedo hacia abajo
            Books = new ObservableCollection<Book>();
            var libros = Repository.getAll();
            foreach (var item in libros)
            {
                Books.Add(item);
            }
            IsRefreshing = false;
        }
        #endregion
    }
}
