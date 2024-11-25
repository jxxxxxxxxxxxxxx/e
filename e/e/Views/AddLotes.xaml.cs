using e.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace e.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLotes : ContentPage
    {
        CRUD create = new CRUD();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private bool _Result;
        public bool Result
        {
            set
            {
                this._isBusy = value;
                OnPropertyChanged();
            }
            get
            {
                return this._isBusy;
            }
        }
        private bool _isBusy;
        public bool isBusy
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
            get
            {
                return this.Result;
            }
        }
        public AddLotes()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (Picker.SelectedIndex == 1)
            {
                dmaceracao.IsVisible = true;
                dpp.IsVisible = true;
                try
                {
                    string dosagem = PickerD.SelectedItem.ToString();
                    string datamaceracao = dmaceracao.Date.ToString("dd/MM/yyyy");
                    string dp = dpp.Date.ToString("dd/MM/yyyy");
                    double v, c, q, l;
                    v = Convert.ToDouble(txt_valdvenda.Text);
                    c = Convert.ToDouble(txt_custo.Text);
                    q = Convert.ToDouble(txt_qtd.Text);
                    l = ((v * q) - (c * q));
                    Result=await create.AddLoteFrutal(txt_lote.Text, txt_sabor.Text, txt_calda.Text, dosagem, datamaceracao, dp, v, c, q, l);
                    if (Result)
                    {
                        await Application.Current.MainPage.DisplayAlert("Sucesso", "Lote Registrado!", "ok"); txt_lote.Text = string.Empty;
                        txt_sabor.Text = string.Empty;
                        txt_calda.Text = string.Empty;
                        Picker.SelectedIndex = 0;
                        PickerD.SelectedIndex = 0;
                        txt_valdvenda.Text = string.Empty;
                        txt_custo.Text = string.Empty;
                        txt_qtd.Text = string.Empty;
                        dmaceracao.Date = DateTime.Today;
                        dpp.Date = DateTime.Today;
                    }
                    else
                    {

                        await Application.Current.MainPage.DisplayAlert("Erro", "Falha, lote préviamente criado, caso queira adicionar ou alterar informações nesse lote, acesse a página 'Alterar Lote'", "ok");
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "ok");
                }
            }
            if (Picker.SelectedIndex == 2)
            {
                dmaceracao.IsVisible= false;
                dpp.IsVisible = false;
                try
                {
                    string dosagem = PickerD.SelectedItem.ToString();
                    double v, c, q, l;
                    v = Convert.ToDouble(txt_valdvenda.Text);
                    c = Convert.ToDouble(txt_custo.Text);
                    q = Convert.ToDouble(txt_qtd.Text);
                    l = ((v * q) - (c * q));
                    Result = await create.AddLoteCremoso(txt_lote.Text, txt_sabor.Text, txt_calda.Text, dosagem, v, c, q, l);
                    if (Result)
                    {
                        await Application.Current.MainPage.DisplayAlert("Sucesso", "Lote Registrado!", "ok"); txt_lote.Text = string.Empty;
                        txt_sabor.Text = string.Empty;
                        txt_calda.Text = string.Empty;
                        Picker.SelectedIndex = 0;
                        PickerD.SelectedIndex = 0;
                        txt_valdvenda.Text = string.Empty;
                        txt_custo.Text = string.Empty;
                        txt_qtd.Text = string.Empty;
                        dmaceracao.Date = DateTime.Today;
                        dpp.Date = DateTime.Today;
                    }
                    else
                    {

                        await Application.Current.MainPage.DisplayAlert("Erro", "Falha, lote préviamente criado, caso queira adicionar ou alterar informações nesse lote, acesse a página 'Alterar Lote'", "ok");
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "ok");
                }
            }
        }
    }
}