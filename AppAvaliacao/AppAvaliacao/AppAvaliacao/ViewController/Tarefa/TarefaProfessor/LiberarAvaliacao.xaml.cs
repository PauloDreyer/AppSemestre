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
	public partial class LiberarAvaliacao : ContentPage
	{
        private TarefaDAO tarefaDAO = new TarefaDAO();

        public LiberarAvaliacao ()
		{
			InitializeComponent ();
            Selecao.Items.Add("Sim");
            Selecao.Items.Add("Não");
        }

        private void Selecao_SelectedIndexChanged(object sender, EventArgs e)
        {
            var opcao = Selecao.Items[Selecao.SelectedIndex];
            if (tarefaDAO.LibBloAvaliacao(opcao))
            {
                Console.WriteLine("Tarefa Liberada!");
            }
            else
            {
                Console.WriteLine("Tarefa Não Liberada!");
            }
        }
    }
}