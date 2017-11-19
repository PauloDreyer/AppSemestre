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
	public partial class NotasTarefasGrupo : ContentPage
	{
        private TarefaDAO tarefaDao = new TarefaDAO();

        public NotasTarefasGrupo ()
		{
			InitializeComponent ();
            LvNotasTarefasGrupo.ItemsSource = tarefaDao.CarregaNotasTarefasGrupo();

        }
	}
}