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
	public partial class TipoUser : ContentPage
	{
		public TipoUser ()
		{
			InitializeComponent ();
		}

        async void onClickProfessor(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarProfessor());
        }

        async void onClickAluno(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarAluno());
        }
    }
}