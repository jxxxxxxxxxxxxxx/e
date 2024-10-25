using e.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e.Ecopontos;
using e.Locais;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace e
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Busca : ContentPage
	{
		public Busca ()
		{
			InitializeComponent ();
		}

        private void Ecopontos(object sender, EventArgs e)
        {
            Navigation.PushAsync(new e.Ecopontos.Estadoss());
        }
        private void ONGs(object sender, EventArgs e)
        {
            Navigation.PushAsync(new e.Locais.Estados());
        }
    }
}