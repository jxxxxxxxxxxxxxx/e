using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using e.Modelo;

namespace e.Ecopontos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Municipioss : ContentPage
    {
        public List<Municipio> ListaInternaMunicipio { get; set; }
        public List<Municipio> ListaFiltradaMunicipio { get; set; }
        public Municipioss (Estado estado)
		{
			InitializeComponent ();
            lblestado.Text = estado.nome.ToString();
            ListaInternaMunicipio = Servico.Servico.GetMunicipio(estado.id);
            ListaMunicipios.ItemsSource = ListaInternaMunicipio;
        }
        private void BuscaRapida(object sender, TextChangedEventArgs args)
        {
            ListaFiltradaMunicipio = ListaInternaMunicipio.Where
                (a => a.nome.Contains(args.NewTextValue)).ToList();
            ListaMunicipios.ItemsSource = ListaFiltradaMunicipio;
        }
        private void Listamunicipio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Municipio municipio = ListaMunicipios.SelectedItem as Municipio;
            Browser.OpenAsync("https://www.google.com/maps/search/EcoPontos em " + municipio.nome, BrowserLaunchMode.SystemPreferred);
        }
    }
}