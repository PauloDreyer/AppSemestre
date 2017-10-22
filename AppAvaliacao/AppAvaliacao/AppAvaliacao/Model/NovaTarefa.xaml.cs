using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao.Model
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovaTarefa : ContentPage
	{
        private TarefaDAO tarefaDAO = new TarefaDAO();
        private Turma turma = Turma.Instancia;
        private string p_nome;
        private int p_id_turma;

        public NovaTarefa ()
		{
			InitializeComponent ();
		}

        private async void onClickCadastar(object sender, EventArgs e)
        {
            p_nome = this.nome.Text;
            p_id_turma = Convert.ToInt32(turma.Id);
            if (tarefaDAO.Inserir(p_nome, p_id_turma))
            {
                Console.WriteLine("Tarefa Cadastrada!");
            }
            else
            {
                Console.WriteLine("Erro ao cadastrar Tarefa!");
            }
            await Navigation.PushAsync(new MasterDetailTurma());
        }
    }
}