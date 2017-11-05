using AppAvaliacao.Model;
using AppAvaliacao.ViewController.Tarefa;
using AppAvaliacao.ViewController.Tarefa.TarefaProfessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao.ViewController.Tarefa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailTarefaProfessorDetail : ContentPage
    {
        private TarefaDAO tarefaDAO = new TarefaDAO();
        private TarefaPostada tarefaPostada =TarefaPostada.Instancia;

        public MasterDetailTarefaProfessorDetail()
        {
            InitializeComponent();
            labelDescricao.Text = tarefaDAO.getDescricaoTarefa();
            lvTarefasPostadas.ItemsSource = tarefaDAO.CarregaTarefasPostadas();
        }

        private void LvTarefasPostadas_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (ListaTarefas)e.SelectedItem;
            tarefaPostada.Id = Convert.ToInt32(itemSelected.IdTarefaPostada);
            Navigation.PushAsync(new TarefaPostadas());
        }
    }
}