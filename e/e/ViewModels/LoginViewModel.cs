using e.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace e.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _UserName;
        public string Username
        {
            set
            {
                this._UserName = value;
                OnPropertyChanged();
            }
            get
            {
                return this._UserName;
            }
        }
        private string _Password;
        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Password;
            }
        }
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
        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }
        private async Task RegisterCommandAsync()
        {
            try
            {
                isBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password);
                if (Result)
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Registrado", "ok");
                }
                else
                {

                    await Application.Current.MainPage.DisplayAlert("Erro", "Falha Registro Préviamente Gravado", "ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "ok");
            }
            finally
            {
                isBusy = false;
            }
        }
        private async Task LoginCommandAsync()
        {
            try
            {
                isBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                if (Result)
                {
                    Preferences.Set("Username", Username);
                    App.Current.MainPage = new Barra_Lateral();
                    await Application.Current.MainPage.DisplayAlert("Login", "Login realizado com sucesso", "ok");
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Erro", "Usuario/Senha invalido(a(s))", "ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "ok");
            }
            finally
            {
                isBusy = false;
            }
        }
    }
}
