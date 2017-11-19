using AppAvaliacao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao.ViewController.App
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EsqueciSenha : ContentPage
	{
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        string p_email;
        string p_senha;
        string p_contraSenha;

		public EsqueciSenha ()
		{
			InitializeComponent ();
		}

        async void btnAlterar_Clicked(object sender, EventArgs e)
        {
            p_email = this.email.Text;
            p_senha = this.senha.Text;
            p_contraSenha = this.ConfSenha.Text;

            if (usuarioDAO.ValidarSenha(p_senha, p_contraSenha))
            {
                if (usuarioDAO.AlterarSenha(p_email, p_senha))
                {
                    Console.WriteLine("Senha Alterada!");
                    await Navigation.PushAsync(new Login());
                }
                else
                {
                    Console.WriteLine("Erro ao Alterar a Senha!");
                }
            }
        }
    }
}