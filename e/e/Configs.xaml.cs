using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;
using Xamarin.Forms.Xaml;

namespace e
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Configs : ContentPage
	{
            public float volume;
            public float pitch =1;
		public Configs ()
		{
			InitializeComponent ();
        }
        private void Lateral(object sender, EventArgs e)
        {
            App.Current.MainPage=(new e.Barra_Lateral());
        }
        private void Inferior(object sender, EventArgs e)
        {
            App.Current.MainPage = (new e.Barra_Inferior());
        }
    }
}