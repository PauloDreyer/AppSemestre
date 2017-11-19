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
        }

        private void SLiberar_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (SLiberar.IsToggled)
            {
                if (tarefaDAO.LibBloAvaliacao(true))
                {
                    Console.WriteLine("Tarefa Liberada!");
                }
            }
            else
            {
                if (tarefaDAO.LibBloAvaliacao(false))
                {
                    Console.WriteLine("Tarefa Não Liberada!");
                }
            }
        }
    }
}