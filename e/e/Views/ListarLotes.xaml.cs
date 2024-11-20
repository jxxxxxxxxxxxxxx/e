using e.Models;
using e.Services;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace e.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarLotes : ContentPage
    {
        FirebaseClient firebase = new FirebaseClient("https://licoratta00-default-rtdb.firebaseio.com/");
        CRUD read = new CRUD();
        public ListarLotes()
        {
            InitializeComponent();
        }

        private async Task ExibeProdutosP()
        {
            var produtos = await read.GetProdutosP();
            ls_produtos.ItemsSource= produtos;
        }
        private async Task ExibeProdutosE()
        {
            var produtos = await read.GetProdutosE();
            ls_produtos.ItemsSource = produtos;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ExibeProdutosP();
        }
        private void Button_Clicked1(object sender, EventArgs e)
        {
            ExibeProdutosE();
        }
    }
}