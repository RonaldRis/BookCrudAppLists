using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotecaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //ESTO ES PARA QUE CUANDO VUELVA A LA PAGINA NO HAYA NINGUNO SELECCIONADO
            ItemsListView.SelectedItem = null;
            base.OnAppearing();
        }

    }
}