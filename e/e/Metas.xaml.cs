using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;
using System.Collections.ObjectModel;
using e.Modelo;
using Xamarin.Essentials;

namespace e
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Metas : ContentPage
    {
        // Classe para representar cada dia
        public class Dia
        {
            public string NomeDia { get; set; }
            public string NomeDiaex { get; set; }
            public string NomeMes { get; set; }
            public int NumeroDiaMes { get; set; }
            public double WidthRequest { get; set; }
        }

        // Coleção observável para os dias da semana
        public ObservableCollection<Dia> Dias { get; set; }

        public Metas()
        {
            InitializeComponent();

            Dias = new ObservableCollection<Dia>();
            PreencherDiasDaSemana();
            DiasCollectionView.ItemsSource = Dias;
        }
        private void PreencherDiasDaSemana()
        {
            double larguraDaTela = Application.Current.MainPage.Width;
            double larguraPorDia = larguraDaTela / 7;
            DateTime hoje = DateTime.Now;
            int diasAteDomingo = DayOfWeek.Sunday - hoje.DayOfWeek;
            DateTime domingo = hoje.AddDays(diasAteDomingo);
            for (int i = 0; i < 7; i++)
            {
                DateTime diaAtual = domingo.AddDays(i);
                Dias.Add(new Dia
                {
                    NomeDia = diaAtual.ToString("ddd", new CultureInfo("pt-BR")),
                    NomeDiaex = diaAtual.ToString("dddd", new CultureInfo("pt-BR")),
                    NumeroDiaMes = diaAtual.Day,
                    NomeMes= diaAtual.ToString("MMMM", new CultureInfo("pt-BR")),
                    WidthRequest = larguraPorDia
                });
            }
        }
        private void DiasCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var diaSelecionado = e.CurrentSelection[0] as Dia;
            DiaSelecionadoLabel.Text = $"Você selecionou {diaSelecionado.NomeDiaex}, dia {diaSelecionado.NumeroDiaMes} de {diaSelecionado.NomeMes}";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://www.wwf.org.br/nosso_trabalho/pegada_ecologica/", BrowserLaunchMode.SystemPreferred);
        }
    }
}