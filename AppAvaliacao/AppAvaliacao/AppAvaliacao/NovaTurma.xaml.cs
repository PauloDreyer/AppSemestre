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
		}
        
        private async void onClickCadastar(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new MasterDetailTurma());
        }
        
    }
}