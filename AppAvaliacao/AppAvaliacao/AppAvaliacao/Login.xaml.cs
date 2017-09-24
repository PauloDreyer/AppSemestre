using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

        async void onClickLogar(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new MasterDetailProfessor());
        }
        
        async void onClickRegistar(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new TipoUser());
        }


    }
}