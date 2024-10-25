using e.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace e.Ecopontos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Estadoss : ContentPage
	{
		public Estadoss ()
        {
            InitializeComponent();
            ListaEstados.ItemsSource =
                Servico.Servico.GetEstados();
        }

        private void ListaEstados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Estado estados = ListaEstados.SelectedItem as Estado;
            Navigation.PushAsync(new Municipioss(estados));
        }
    }
}