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
using static e.Metas;

namespace e
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Metas : ContentPage
    {
        public class Dia
        {
            public string NomeDia { get; set; }
            public string NomeDiaex { get; set; }
            public string NomeMes { get; set; }
            public int NumeroDiaMes { get; set; }
            public double WidthRequest { get; set; }
            public string Textocor { get; set; }
            public string TextoCor { get; internal set; }
            public string CorFundo { get; internal set; }
            public bool IsSelecionado { get; set; }
        }

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
            foreach (var dia in Dias)
            {
                dia.IsSelecionado = false;
                dia.TextoCor = "White";
            }
        }
        private void DiasCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var dia in Dias)
            {
                dia.IsSelecionado = false;
                dia.TextoCor = "White";
                dia.CorFundo = "transparent";
            }
            var diaSelecionado = (Dia)e.CurrentSelection[0];
            if (e.CurrentSelection.Count > 0)
            {
                diaSelecionado.IsSelecionado = true;
                diaSelecionado.TextoCor = "#acbd24";
                diaSelecionado.CorFundo = "#d8ee9c";
            }
            DiasCollectionView.ItemsSource = null;
            DiasCollectionView.ItemsSource = Dias;
            DiaSelecionadoLabel.Text = $"Você selecionou {diaSelecionado.NomeDiaex}, dia {diaSelecionado.NumeroDiaMes} de {diaSelecionado.NomeMes}";
            DiaSelecionadoLabel.FontFamily = "sans-serif-thin";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://www.wwf.org.br/nosso_trabalho/pegada_ecologica/", BrowserLaunchMode.SystemPreferred);
        }
    }
}