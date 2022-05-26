using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM022PP0122
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        public SecondPage(String pnombre, String pedad)
        {
            InitializeComponent();

            lbnombre.Text = pnombre;
            lbedad.Text = pedad;
        }
    }
}