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
    public partial class MasterDetailTarefaAlunoDetail : ContentPage
    {
        TarefaPostadaDAO tarefaPostadaDAO = new TarefaPostadaDAO();
        private TarefaDAO tarefaDAO = new TarefaDAO();
        TarefaPostada tarefaPostada = TarefaPostada.Instancia;

        public MasterDetailTarefaAlunoDetail()
        {
            InitializeComponent();
            labelDescricao.Text = tarefaDAO.getDescricaoTarefa();
            tarefaPostada = tarefaPostadaDAO.GetTarefaPostada();
            Tarefa.Text = tarefaPostada.Tarefa;
        }
    }
}