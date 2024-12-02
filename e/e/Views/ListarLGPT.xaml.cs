using e.Services;
using Firebase.Database;
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
    public partial class ListarLGPT : ContentPage
    {
        FirebaseClient firebase = new FirebaseClient("https://licoratta00-default-rtdb.firebaseio.com/");
        CRUD read = new CRUD();
        public ListarLGPT()
        {
            InitializeComponent();
        }

        private async Task ExibeGarrafas()
        {
            var produtos = await read.GetGarrafas();
            ls_produtos.ItemsSource = produtos;
        }
        private async Task ExibeLacres()
        {
            var produtos = await read.GetLacres();
            ls_produtos.ItemsSource = produtos;
        }
        private async Task ExibePapelaria()
        {
            var produtos = await read.GetPapelaria();
            ls_produtos.ItemsSource = produtos;
        }
        private async Task ExibeTampas()
        {
            var produtos = await read.GetTampas();
            ls_produtos.ItemsSource = produtos;
        }
        private async Task Exibe()
        {
            //var produtos = await read.GetLGPT();
            //ls_produtos.ItemsSource = produtos;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Exibe();
        }
        private void Button_Clicked1(object sender, EventArgs e)
        {
            ExibeLacres();
        }
        private void Button_Clicked2(object sender, EventArgs e)
        {
            ExibeGarrafas();
        }
        private void Button_Clicked3(object sender, EventArgs e)
        {
            ExibePapelaria();
        }
        private void Button_Clicked4(object sender, EventArgs e)
        {
            ExibeTampas();
        }
    }
}