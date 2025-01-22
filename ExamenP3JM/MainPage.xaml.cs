using ExamenP3JM.Interfaces;
using ExamenP3JM.ViewModels;

namespace ExamenP3JM
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new BusquedaViewModel(new PeliculaInterface());
        }

      
    }

}
