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
                string dosagem=PickerD.SelectedItem.ToString();
                string datamaceracao = dmaceracao.Date.ToString("dd/MM/yyyy");
                string dp = dpp.Date.ToString("dd/MM/yyyy");
                double v, c, q, l;
                v = Convert.ToDouble(txt_valdvenda.Text);
                c = Convert.ToDouble(txt_custo.Text);
                q = Convert.ToDouble(txt_qtd.Text);
                l = ((v * q) - (c * q));
                Update.UpdateProdutoP(txt_lote.Text, txt_sabor.Text, txt_calda.Text, dosagem, datamaceracao, dp,  v, c, q, l);
                txt_lote.Text = string.Empty;
                txt_sabor.Text = string.Empty;
                txt_calda.Text = string.Empty;
                PickerD.SelectedIndex = 0;
                txt_valdvenda.Text = string.Empty;
                txt_custo.Text = string.Empty;
                txt_qtd.Text = string.Empty;
                dmaceracao.Date = DateTime.Today;
                dpp.Date = DateTime.Today;
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
            if (p.Dosagem == "50ml")
            {
                PickerD.SelectedIndex=1;
            }
            else if (p.Dosagem == "250ml")
            {
                PickerD.SelectedIndex = 2;
            }
            else if (p.Dosagem == "500ml")
            {
                PickerD.SelectedIndex = 3;
            }
            else if (p.Dosagem == "1L")
            {
                PickerD.SelectedIndex = 4;
            }
            txt_valdvenda.Text = p.ValdVenda.ToString();
            txt_custo.Text = p.Custo.ToString();
            txt_qtd.Text = p.Quantidade.ToString();
            string[] partes = p.DMaceracao.Split('/');
            string dia = partes[0];
            string mes = partes[1];
            string ano = partes[2];
            string data = mes + "/" + dia + "/" + ano;
            dmaceracao.Date=DateTime.Parse(data);
            string[] part = p.DP.Split('/');
            string d = part[0];
            string m = part[1];
            string a = part[2];
            string date = m + "/" + d + "/" + a;
            dpp.Date = DateTime.Parse(date);
        }
    }
}