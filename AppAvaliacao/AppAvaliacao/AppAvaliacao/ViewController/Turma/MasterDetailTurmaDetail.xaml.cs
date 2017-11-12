using AppAvaliacao.Model;
using AppAvaliacao.ViewController.Tarefa;
using AppAvaliacao.ViewController.Tarefa.TarefaAluno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailTurmaDetail : ContentPage
    {
        private TarefaDAO tarefaDAO = new TarefaDAO();
        private Tarefa tarefa = Tarefa.Instancia;
        private Usuario usuario = Usuario.Instancia;

        public MasterDetailTurmaDetail()
        {
            InitializeComponent();
            lvTarefas.ItemsSource = tarefaDAO.CarregaTarefas();
        }

        private void LvTarefas_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (ListaTarefas)e.SelectedItem;
            tarefa.Id = Convert.ToInt32(itemSelected.Id);
            if (usuario.Tipo.Equals("P"))
            {
                Navigation.PushAsync(new MasterDetailTarefaProfessor());
            }
            else
            {
                Navigation.PushAsync(new MasterDetailTarefaAluno());
            }
        }
    }
}