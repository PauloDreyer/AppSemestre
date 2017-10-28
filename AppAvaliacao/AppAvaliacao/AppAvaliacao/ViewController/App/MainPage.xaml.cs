using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppAvaliacao
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        void onClick(object sender, EventArgs e)
        {
        
            Navigation.PushAsync(new TipoUser(),true);
        }
	}
}
