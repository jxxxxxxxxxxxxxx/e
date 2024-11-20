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
    public partial class AlterarLote : ContentPage
    {
        CRUD Update = new CRUD();
        public AlterarLote()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string datamaceracao = dmaceracao.Date.ToString("dd/MM/yyyy");
                double v, c, q, l;
                v = Convert.ToDouble(txt_valdvenda.Text);
                c = Convert.ToDouble(txt_custo.Text);
                q = Convert.ToDouble(txt_qtd.Text);
                l = ((v * q) - (c * q));
                Update.UpdateProdutoP(txt_lote.Text, txt_sabor.Text, txt_calda.Text, txt_dosagem.Text, datamaceracao, v, c, q, l);
                txt_lote.Text = string.Empty;
                txt_sabor.Text = string.Empty;
                txt_calda.Text = string.Empty;
                txt_dosagem.Text = string.Empty;
                txt_valdvenda.Text = string.Empty;
                txt_custo.Text = string.Empty;
                txt_qtd.Text = string.Empty;
                dmaceracao.Date = DateTime.Today;
                DisplayAlert("", "Lote Alterado com Sucesso", "Ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("", "Lote não encontrado", "Ok");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var p= await Update.GetProdutooP(txt_lote.Text);
            txt_sabor.Text = p.Sabor;
            txt_calda.Text = p.Calda;
            txt_dosagem.Text = p.Dosagem;
            txt_valdvenda.Text = p.ValdVenda.ToString();
            txt_custo.Text = p.Custo.ToString();
            txt_qtd.Text = p.Quantidade.ToString();
            string[] partes = p.DMaceracao.Split('/');
            string dia = partes[0];
            string mes = partes[1];
            string ano = partes[2];
            string data = mes + "/" + dia + "/" + ano;
            dmaceracao.Date=DateTime.Parse(data);
        }
    }
}