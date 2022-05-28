using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM022PP0122.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM022PP0122.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

        private async void toolmenu1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmplePage());
        }

        private async void ListaEmpleados_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Emple = (Empleado)e.Item;
            //await DisplayAlert("Aviso","Elemento Seleccionado " + Emple.nombre, "OK");

            bool answer = await DisplayAlert("Aviso", "Empleado Seleccionado: \n" + Emple.nombre, "Ver info.", "OK");
            //Debug.WriteLine("Answer: " + answer);
            if (answer){verinfo(Emple);}
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ListaEmpleados.ItemsSource = await App.DBase.obtenerListaEmple();
        }

        #region Metodos
        private async void verinfo(Empleado empleado)
        {
            /*var emple = new Empleado
            {
                id = 1,
                nombre = "Prueba",
                edad = "18",
                sexo = "Masculino",
                fechaingreso = new DateTime(2008, 5, 1, 8, 30, 52)
            };*/

            var fecha = empleado.fechaingreso.ToString("MM/dd/yyyy");

            var secondPage = new Carnet();
            secondPage.BindingContext = new {empleado, fecha};
            await Navigation.PushAsync(secondPage);
        }
        #endregion
    }
}