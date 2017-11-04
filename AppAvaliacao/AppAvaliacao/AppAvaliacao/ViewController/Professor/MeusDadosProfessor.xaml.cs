using AppAvaliacao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao.ViewController.Professor
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MeusDadosProfessor : ContentPage
	{
        private Usuario usuario = Usuario.Instancia;
        private UsuarioDAO usuarioDAO = new UsuarioDAO();
        private string p_nome;
        private int p_matricula;
        private string p_email;
        private string p_senha;
        private string p_contraSenha;

        public MeusDadosProfessor ()
		{
			InitializeComponent ();
            nome.Text = usuario.Nome;
            email.Text = usuario.Email;
            senha.Text = usuario.Senha;
            confSenha.Text = usuario.Senha;
        }

        async void onClickAlterar(object sender, EventArgs e)
        {
            p_nome = this.nome.Text;
            p_email = this.email.Text;
            p_senha = this.senha.Text;
            p_contraSenha = this.confSenha.Text;
            p_matricula = Convert.ToInt32(usuario.Matricula);

            if (usuarioDAO.ValidarSenha(p_senha, p_contraSenha))
            {
                if (usuarioDAO.Alterar(p_nome, p_matricula, p_email, p_senha))
                {
                    Console.WriteLine("Usuário Alterado!");
                    await Navigation.PushAsync(new MasterDetailProfessor());
                }
                else
                {
                    Console.WriteLine("Erro ao alterar usuário!");
                }
            }
        }
    }
}