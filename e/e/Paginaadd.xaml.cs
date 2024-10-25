using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace e
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Paginaadd : ContentPage
    {
        public string diaselecionado, messelecionado, anoselecionado;

        private void Button_Clicked(object sender, EventArgs e)
        {
            string ntarefa=nometarefa.Text;
            if (ntarefa=="")
            {
                DisplayAlert("Mensagem", "Campo 'Nome da Tarefa' Vazio", "OK");
            }
            else
            {
                //Banco_funcoes dbf = new Banco_funcoes();
                //dbf.CriarBancoDeDados();
                //dbf.InserirCliente(ntarefa, diaselecionado, messelecionado, anoselecionado);
                DisplayAlert("Mensagem", "Tarefa: "+ntarefa+" adicionada com Sucesso!", "OK");
            }
            Navigation.PopModalAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        public Paginaadd(string ndia, string nmes, string nano)
        {
            InitializeComponent();
            diaselecionado = ndia;
            messelecionado = nmes;
            anoselecionado = nano;
        }
    }
}