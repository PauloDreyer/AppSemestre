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
        TarefaDAO tarefaDao = new TarefaDAO();
        int id_tarefa_postada = 0;
        bool statusTarefa;

        public PostarTarefa ()
		{
			InitializeComponent ();
            if(tarefaPostadaDAO.ExisteTarefaPostada())
            {
                statusTarefa = tarefaDao.GetStatusTarefa();
                tarefaPostada = tarefaPostadaDAO.GetTarefaPostada();
                id_tarefa_postada = tarefaPostada.Id;
                Tarefa.Text = tarefaPostada.Tarefa;
                if (!statusTarefa)
                {
                    TarefaLib.Text = "A tarefa não pode ser Postada ou Editada!";
                }
            }
        }

        private void Postar_Clicked(object sender, EventArgs e)
        {
            if (statusTarefa)
            {
                if (id_tarefa_postada == 0)
                {
                    tarefaPostadaDAO.PostarTarefa(Tarefa.Text);
                }
                else
                {
                    tarefaPostadaDAO.AtualizarTarefaPostada(Tarefa.Text);
                }
            }
            Navigation.PushAsync(new MasterDetailTarefaAluno());

        }
    }
}