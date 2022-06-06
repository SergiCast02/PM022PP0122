﻿using System;
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
            try
            {
                var _nombre = txtnombre.Text;
                var _edad = txtedad.Text;
                var _sexo = sexo.SelectedItem.ToString();
                var _fechaingreso = fecha.Date;

                var emple = new Empleado
                {
                    id = 0,
                    nombre = _nombre,
                    edad = _edad,
                    sexo = _sexo,
                    fechaingreso = _fechaingreso
                };

                var result = await App.DBase.EmpleSave(emple);
                if (result > 0)
                {
                    await DisplayAlert("Aviso", "Empleado adicionado", "OK");
                }
                else
                {
                    await DisplayAlert("Aviso", "Ha ocurrido un error", "OK");
                }

                bool answer = await DisplayAlert("Aviso", "¿Desea vaciar el formulario?", "Si", "No");
                //Debug.WriteLine("Answer: " + answer);
                if (answer)
                {
                    txtid.Text = null;
                    txtnombre.Text = null;
                    txtedad.Text = null;
                    sexo.SelectedItem = null;
                    fecha.Date = DateTime.Today;
                }
            }
            catch
            {
                await DisplayAlert("Aviso", "No ha rellenado todos los campos", "OK");
            }
        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var _id = Convert.ToInt32(txtid.Text);
                var _nombre = txtnombre.Text;
                var _edad = txtedad.Text;
                var _sexo = sexo.SelectedItem.ToString();
                var _fechaingreso = fecha.Date;

                var emple = new Empleado
                {
                    id = _id,
                    nombre = _nombre,
                    edad = _edad,
                    sexo = _sexo,
                    fechaingreso = _fechaingreso
                };

                var result = await App.DBase.EmpleDelete(emple);
            }
            catch (Exception)
            {
                await DisplayAlert("Aviso", "No ha rellenado todos los campos", "OK");
            }
        }

        private async void btnpageemple_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PagePrincipal());
        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var _id = Convert.ToInt32(txtid.Text);
                var _nombre = txtnombre.Text;
                var _edad = txtedad.Text;
                var _sexo = sexo.SelectedItem.ToString();
                var _fechaingreso = fecha.Date;

                var emple = new Empleado
                {
                    id = _id,
                    nombre = _nombre,
                    edad = _edad,
                    sexo = _sexo,
                    fechaingreso = _fechaingreso
                };

                var result = await App.DBase.EmpleSave(emple);
            }
            catch (Exception)
            {
                await DisplayAlert("Aviso", "No ha rellenado todos los campos", "OK");
            }
        }

        private async void btnbuscaremple_Clicked(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(txtid.Text);
            Empleado emple = await App.DBase.obtenerEmple(id);

            txtid.Text = ""+emple.id;
            txtnombre.Text = emple.nombre;
            txtedad.Text = emple.edad;
            sexo.SelectedItem = emple.sexo;
            fecha.Date = emple.fechaingreso;
        }

        private void btnlimpiar_Clicked(object sender, EventArgs e)
        {
            txtid.Text = null;
            txtnombre.Text = null;
            txtedad.Text = null;
            sexo.SelectedItem = null;
            fecha.Date = DateTime.Today;
        }
    }
}