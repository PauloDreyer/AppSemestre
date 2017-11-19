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
	public partial class ParticiparGrupo : ContentPage
	{
        private TarefaPostadaDAO tarefaPostadaDAO = new TarefaPostadaDAO();

        public ParticiparGrupo ()
		{
			InitializeComponent ();
            Tarefa.Text = tarefaPostadaDAO.ExibirTarefa();
            LvAlunosTarefa.ItemsSource = tarefaPostadaDAO.CarregaAlunos();
        }

        private void Participar_Clicked(object sender, EventArgs e)
        {
            if (tarefaPostadaDAO.VincularAlunoTarefa())
            {
                Navigation.PushAsync(new MasterDetailTarefaAluno());
            }
        }
    }
}