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
	public partial class AlterarTarefa : ContentPage
	{
        private Model.Tarefa tarefa = Model.Tarefa.Instancia;
        private TarefaDAO tarefaDao = new TarefaDAO();
        private string p_nome;
        private string p_descricao;
        private DateTime p_data;
        private string p_status;

		public AlterarTarefa ()
		{
			InitializeComponent ();
            nome.Text = tarefa.Nome;
            descricao.Text = tarefa.Descricao;
            status.Text = tarefa.Status; 
            
		}

        async void Alterar_Clicked(object sender, EventArgs e)
        {
            p_nome = nome.Text;
            p_descricao = descricao.Text;
            p_status = status.Text;

            if (tarefaDao.AlterarTarefa(p_nome, p_descricao, p_status))
            {
                Console.WriteLine("Tarefa Alterada");
                await Navigation.PushAsync(new MasterDetailTarefaProfessor());
            }
            else
            {
                Console.WriteLine("Erro ao Alterar a Tarefa");
            }
        }
    }
}