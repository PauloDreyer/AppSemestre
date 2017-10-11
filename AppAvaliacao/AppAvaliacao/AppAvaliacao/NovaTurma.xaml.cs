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
	public partial class NovaTurma : ContentPage
	{
		public NovaTurma ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);
            
            
		}

        async void onClickCadastar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MasterDetailTurma());
        }
    }
}