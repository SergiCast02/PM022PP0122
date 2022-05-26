using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM022PP0122
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(DateTime date)
        {
            InitializeComponent();
        }

        private async void btnmostrar_Clicked(object sender, EventArgs e)
        {
            //String.Format("Nombre: {0} Edad: {1} Aviso", txtnombre.Text, txtedad.Text);
            await DisplayAlert("Aviso", "Nombre: " + txtnombre.Text + " Edad: " + txtedad.Text, "OK");
        }

        private async void btnpagina_Clicked(object sender, EventArgs e)
        {
            var emple = new Models.Empleado
            {
                id = 0,
                nombre = txtnombre.Text,
                edad = txtedad.Text
            };

            /*
            var segunda = new SecondPage();
            segunda.BindingContext = emple;
            await Navigation.PushAsync(segunda);
            */

            await Navigation.PushAsync(new SecondPage(txtnombre.Text, txtedad.Text));
        }
    }
}
