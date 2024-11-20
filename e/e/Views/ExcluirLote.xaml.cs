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
    public partial class ExcluirLote : ContentPage
    {
        CRUD delete=new CRUD();
        public ExcluirLote()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (txt_sabor.Text == string.Empty)
            {
                DisplayAlert("Erro", "Defina o sabor a ser excluído", "Ok");
            }
            else
            {
                try
                {
                    delete.DeleteProdutoP(txt_lote.Text, txt_sabor.Text);
                    txt_lote.Text = string.Empty;
                    txt_sabor.Text = string.Empty;
                    DisplayAlert("", "Lote Excluído com Sucesso", "Ok");
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro", "Lote não encontrado", "Ok");
                }
            }
        }
        private void Button_Clicked1(object sender, EventArgs e)
        {
            if (txt_sabor.Text == string.Empty)
            {
                DisplayAlert("Erro", "Defina o sabor a ser excluído", "Ok");
            }
            else
            {
                try
                {
                    delete.DeleteProdutoE(txt_lote.Text, txt_sabor.Text);
                    txt_lote.Text = string.Empty;
                    txt_sabor.Text = string.Empty;
                    DisplayAlert("", "Lote Excluído com Sucesso", "Ok");
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro", "Lote não encontrado", "Ok");
                }
            }
        }
    }
}