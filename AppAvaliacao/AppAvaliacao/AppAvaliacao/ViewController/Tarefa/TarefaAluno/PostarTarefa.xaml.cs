using AppAvaliacao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao.ViewController.Tarefa.TarefaAluno
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostarTarefa : ContentPage
	{
        TarefaPostadaDAO tarefaPostadaDAO = new TarefaPostadaDAO();
        TarefaPostada tarefaPostada = TarefaPostada.Instancia;
        int id_tarefa_postada = 0;

        public PostarTarefa ()
		{
			InitializeComponent ();
            if(tarefaPostadaDAO.ExisteTarefaPostada())
            {
                tarefaPostada = tarefaPostadaDAO.GetTarefaPostada();
                id_tarefa_postada = tarefaPostada.Id;
                Tarefa.Text = tarefaPostada.Tarefa;
            }
        }

        private void SelecionarAlunos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SelecionarAlunos());
        }

        private void Postar_Clicked(object sender, EventArgs e)
        {
            if(id_tarefa_postada == 0)
            {
                tarefaPostadaDAO.PostarTarefa(Tarefa.Text);
            }
            else
            {
                tarefaPostadaDAO.AtualizarTarefaPostada(Tarefa.Text);
            }
            
        }
    }
}