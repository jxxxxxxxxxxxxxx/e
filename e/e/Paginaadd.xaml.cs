using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e.banco;
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
            if (ntarefa== "" || ntarefa=="Nome da Meta" )
            {
                DisplayAlert("Mensagem", "Defina um nome para sua nova Meta", "OK");
            }
            else
            {
                Banco_funcoes dbf = new Banco_funcoes();
                dbf.CriarBancoDeDados();
                dbf.AddTarefas(ntarefa, diaselecionado, messelecionado, anoselecionado);
                DisplayAlert("Mensagem", "A Meta: "+ntarefa+" adicionada com Sucesso!", "OK");
                Navigation.PopModalAsync();
            }
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