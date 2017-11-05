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
	public partial class Avaliacao : ContentPage
	{
        private TarefaPostadaDAO tarefaPostadaDao = new TarefaPostadaDAO();
		public Avaliacao ()
		{
			InitializeComponent ();
		}

        private void Postar_Clicked(object sender, EventArgs e)
        {
            tarefaPostadaDao.PostarComentario(this.Comentario.Text);
            tarefaPostadaDao.PostarNotas(Convert.ToDecimal(this.Nota.Text));
        }
    }
}