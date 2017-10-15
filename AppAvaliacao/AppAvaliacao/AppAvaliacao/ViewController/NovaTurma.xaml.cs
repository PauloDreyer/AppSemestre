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
	public partial class NovaTurma : ContentPage
	{
        private ConMySql conexao;
        private string error;
        private Usuario professor = Usuario.Instancia;
        private string p_nome;
        private int p_id_professor;

        public NovaTurma ()
		{
			InitializeComponent ();   
		}
        
        private async void onClickCadastar(object sender, EventArgs e)
        {
            conexao = new ConMySql();

            if (conexao.TryConnection(out error))
            {
                p_nome = this.nome.Text;
                p_id_professor = Convert.ToInt32(professor.Id);
                if (conexao.InserirTurma(p_nome, p_id_professor))
                {
                    Console.WriteLine("Turma Cadastrada!");
                }
                else
                {
                    Console.WriteLine("Erro: " + error);
                }
                await Navigation.PushAsync(new MasterDetailProfessor());
            }
        }
        
    }
}