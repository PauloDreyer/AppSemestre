using AppAvaliacao.Model;
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
	public partial class InscricaoTurma : ContentPage
	{
        private TurmaDAO turmaDAO = new TurmaDAO();
        private Usuario aluno = Usuario.Instancia;
        private int p_idInscricao;

        public InscricaoTurma ()
		{
			InitializeComponent ();
		}

        private async void onClickCadastar(object sender, EventArgs e)
        {
            p_idInscricao = Convert.ToInt32(this.idInscricao.Text);
            
            if (turmaDAO.InserirAlunoTurma(p_idInscricao, Convert.ToInt32(aluno.Id)))
            {
                Console.WriteLine("Aluno cadastrado na turma!");
            }
            else
            {
                Console.WriteLine("Erro ao cadastrar aluno na turma!");
            }
            await Navigation.PushAsync(new MasterDetailAluno());
        }
    }
}