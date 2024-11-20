using e.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace e.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PesquisarLote : ContentPage
    {
        CRUD read=new CRUD();
        public PesquisarLote()
        {
            InitializeComponent();
        }

        private async Task ExibeProdutossabor()
        {
            var produtos = await read.GetProdutosaborP(txt_sabor.Text);
            ls_produtos.ItemsSource = produtos;
        }

        private async Task ExibeProdutosdosagem()
        {
            var produtos = await read.GetProdutodosagemP(txt_dosagem.Text);
            ls_produtos.ItemsSource = produtos;
        }

        private async Task ExibeProdutoscalda()
        {
            var produtos = await read.GetProdutocaldaP(txt_calda.Text);
            ls_produtos.ItemsSource = produtos;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            ExibeProdutossabor();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            ExibeProdutosdosagem();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            ExibeProdutoscalda();
        }
    }
}