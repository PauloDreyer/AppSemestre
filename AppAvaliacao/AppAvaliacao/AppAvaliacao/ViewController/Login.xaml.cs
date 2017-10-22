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
        private UsuarioDAO usuarioDAO = new UsuarioDAO();

        public Login ()
		{
			InitializeComponent ();
            
		}

        async void onClickLogar(object sender, EventArgs e)
        {
            string p_email;
            string p_senha;
            string p_tipo;
            p_email = this.email.Text;
            p_senha = this.senha.Text;
            if (usuarioDAO.Logar(p_email, p_senha, out p_tipo))
                {
                if (p_tipo == "P")
                {
                    await Navigation.PushAsync(new MasterDetailProfessor());
                }
                else if (p_tipo == "A")
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