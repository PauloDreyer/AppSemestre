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
	public partial class NotasTarefa : ContentPage
	{
        private TarefaDAO tarefaDao = new TarefaDAO();
		public NotasTarefa ()
		{
			InitializeComponent ();
            LvNotasTarefa.ItemsSource = tarefaDao.CarregaNotasTarefas();
        }
	}
}