using MySql.Data.MySqlClient;
using System;
using System.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using AppAvaliacao.Model;
using Java.Lang;
using Android.Widget;

namespace AppAvaliacao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        private ConMySql conexao;
        private string error;

        public Login ()
		{
			InitializeComponent ();
            
		}

           
        async void onClickLogar(object sender, EventArgs e)
        {
            string p_email;
            string p_senha;
            conexao = new ConMySql();
            if (conexao.TryConnection(out error))
            {
                p_email = this.email.Text;
                p_senha = this.senha.Text;
                if (conexao.Logar(p_email, p_senha))
                {
                    await Navigation.PushAsync(new MasterDetailProfessor());
                }
            }

        }

        async void onClickRegistar(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new TipoUser());
        }


    }
}