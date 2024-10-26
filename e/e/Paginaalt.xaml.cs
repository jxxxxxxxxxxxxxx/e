using e.banco;
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
    public partial class Paginaalt : ContentPage
    {
        public string ntarefaa;
        public Paginaalt(string ntarefa)
        {
            InitializeComponent();
            ntarefaa = ntarefa;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string ntarefaaa = nometarefa.Text;
            if (ntarefaaa == "" || ntarefaaa== "Novo Nome para Meta")
            {
                DisplayAlert("Mensagem", "Defina o novo nome para a Meta", "OK");
            }
            else
            {
                Banco_funcoes dbf = new Banco_funcoes();
                dbf.CriarBancoDeDados();
                dbf.EditarTarefa(ntarefaaa, ntarefaa);
                DisplayAlert("Mensagem", "A Meta: " + ntarefaa + " foi alterada para "+ntarefaaa+" com sucesso!", "OK");
                Navigation.PopModalAsync();
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}