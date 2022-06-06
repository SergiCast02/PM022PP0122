using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Media;

namespace PM022PP0122.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoPage : ContentPage
    {
        public PhotoPage()
        {
            InitializeComponent();
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            var Fotografia = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MisFotos",
                Name = "test.jpg",
                SaveToAlbum = true
            });

            await DisplayAlert("Path directorio", Fotografia.Path, "OK");

            if(Fotografia != null)
            {
                Foto.Source = ImageSource.FromStream(() =>
                {
                    return Fotografia.GetStream();
                });
            }
        }
    }
}