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
using e.banco;

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
            public string Numeromes { get; set; }
            public int NumeroDiaMes { get; set; }
            public string Ano { get; set; }
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
                    Ano = diaAtual.Year.ToString(),
                    Numeromes =diaAtual.Month.ToString(),
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
            DiaSelecionadoLabel.Text = $"{diaSelecionado.NomeDiaex}, dia {diaSelecionado.NumeroDiaMes} de {diaSelecionado.NomeMes}";
            DiaSelecionadoLabel.FontFamily = "sans-serif-thin";
            listar();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://www.wwf.org.br/nosso_trabalho/pegada_ecologica/", BrowserLaunchMode.SystemPreferred);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
                var diaselecionado = (Dia)DiasCollectionView.SelectedItem;
                var diaselectwed = (Dia)DiasCollectionView.SelectedItem;
                var diaselected = (Dia)DiasCollectionView.SelectedItem;
                if (diaselecionado != null && diaselectwed != null && diaselected != null)
                {
                    string ndia = diaselecionado.NumeroDiaMes.ToString();
                    string nmes = diaselecionado.NomeMes.ToString();
                    string nano = diaselecionado.Ano.ToString();
                    Navigation.PushModalAsync(new Paginaadd(ndia, nmes, nano));
                }
                else
                {
                    DisplayAlert("Alerta", "Nenhuma data foi selecionada para adicionar uma meta", "Ok");
                }

        }
        public void listar()
        {
            var diaselecionado = (Dia)DiasCollectionView.SelectedItem;
            var diaselectwed = (Dia)DiasCollectionView.SelectedItem;
            var diaselected = (Dia)DiasCollectionView.SelectedItem;
            if (diaselecionado != null && diaselectwed != null && diaselected != null)
            {
                string ndia = diaselecionado.NumeroDiaMes.ToString();
                string nmes = diaselecionado.NomeMes.ToString();
                string nano = diaselecionado.Ano.ToString();
                Banco_funcoes dbf = new Banco_funcoes();
                dbf.CriarBancoDeDados();
                List<Expo> listatarefas = new List<Expo>();
                listatarefas = dbf.GetTarefas(ndia, nmes, nano);
                var array = listatarefas.ToArray();
                List<Expo> lista = new List<Expo>();
                for (int c = 0; c < array.Length; c++)
                {
                    lista.Add(new Expo
                    {
                        Tarefa = array[c].Tarefa,
                        Dia = array[c].Dia,
                        Mes = array[c].Mes,
                        Ano = array[c].Ano,
                        Concluida = array[c].Concluida,
                    });
                }
                ls_tarefas.ItemsSource = lista;
            }
            else
            {
                DisplayAlert("Alerta", "Nenhuma data foi selecionada para listar as metas", "Ok");
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            listar();
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            var tarefaselecionada = (Expo)ls_tarefas.SelectedItem;
            string nometarefa = tarefaselecionada.Tarefa.ToString();
            Navigation.PushModalAsync(new Paginaalt(nometarefa));
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            var diaselecionado = (Dia)DiasCollectionView.SelectedItem;
            var diaselectwed = (Dia)DiasCollectionView.SelectedItem;
            var diaselected = (Dia)DiasCollectionView.SelectedItem;
            var tarefaselecionada = (Expo)ls_tarefas.SelectedItem;
            string ndia = diaselecionado.NumeroDiaMes.ToString();
            string nmes = diaselecionado.NomeMes.ToString();
            string nano = diaselecionado.Ano.ToString();
            string nometarefa = tarefaselecionada.Tarefa.ToString();
            Banco_funcoes dbf = new Banco_funcoes();
            dbf.CriarBancoDeDados();
            dbf.Excluirtarefa(nometarefa, ndia, nmes, nano);
            DisplayAlert("Mensagem", "Meta: "+nometarefa+" excluída com Sucesso!", "OK");
            listar();
            alt.IsVisible = false;
            del.IsVisible = false;
            alt.IsEnabled = false;
            del.IsEnabled = false;
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                DisplayAlert("Parabéns", "Meta Concluída!!!", "Eba!");
            }
        }

        private void ls_tarefas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ls_tarefas.SelectedItem == null)
            {
                alt.IsVisible = false;
                del.IsVisible = false;
                alt.IsEnabled = false;
                del.IsEnabled = false;
            }
            else
            {
                alt.IsVisible = true;
                del.IsVisible = true;
                alt.IsEnabled = true;
                del.IsEnabled = true;
            }
        }

    }
}