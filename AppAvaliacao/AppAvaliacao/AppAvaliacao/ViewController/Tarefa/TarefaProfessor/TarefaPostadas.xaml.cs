using AppAvaliacao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao.ViewController.Tarefa.TarefaProfessor
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TarefaPostadas : ContentPage
	{
        private TarefaPostadaDAO tarefaPostadaDAO = new TarefaPostadaDAO();

        public TarefaPostadas ()
		{
			InitializeComponent ();
            Tarefa.Text = tarefaPostadaDAO.ExibirTarefa();
            LvAlunosTarefa.ItemsSource = tarefaPostadaDAO.CarregaAlunos();

        }

        private void Avaliar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Avaliacao());
        }
    }
}