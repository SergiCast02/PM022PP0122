using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM022PP0122.Models;
using PM022PP0122.Controller;

namespace PM022PP0122.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmplePage : ContentPage
    {
        public EmplePage()
        {
            InitializeComponent();
        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            var emple = new Empleado
            {
                id = 0,
                nombre = txtnombre.Text,
                edad = txtedad.Text,
                sexo = sexo.SelectedItem.ToString(),
                fechaingreso = fecha.Date
            };

            var result = await App.DBase.EmpleSave(emple);
            if (result > 0)
            {
                await DisplayAlert("Empleado Adicionado", "Aviso", "OK");
            }
            else
            {
                await DisplayAlert("Ha ocurrido un error", "Aviso", "OK");
            }
        }

        private void btneliminar_Clicked(object sender, EventArgs e)
        {

        }
    }
}