using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BibliotecaApp.Models;
using BibliotecaApp.ViewModels;

namespace BibliotecaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {

        public NewItemPage(bool isNew,Book libro)
        {
            InitializeComponent();
            //ESTO LO HAGO PARA IDENTIFICAR POR CUAL METODO DE NAVIGATION PUSH ENTRÓ
            //Si la intención era crear un nuevo registro
            //En caso que no, es porque va a actualizar, por eso habilito para eliminar
            if (isNew)
            {
                btnEliminar.IsVisible = false;
            }
            else
            {
                btnEliminar.IsVisible = true;
            }
            BindingContext = new NewItemViewModel(isNew,libro);
        }

    }
}