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
	public partial class ParticiparTarefa : ContentPage
	{
        private TarefaPostadaDAO tarefaPostadaDAO = new TarefaPostadaDAO();
        private TarefaPostada tarefaPostada = TarefaPostada.Instancia;

        public ParticiparTarefa ()
		{
			InitializeComponent ();
            LvTarefasGruposAlunos.ItemsSource = tarefaPostadaDAO.CarregaTarefasGrupos();

        }


        private void LvTarefasGruposAlunos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (ListaTarefas)e.SelectedItem;
            tarefaPostada.Id = Convert.ToInt32(itemSelected.IdTarefaPostada);
            Navigation.PushAsync(new ParticiparGrupo());
        }
    }
}