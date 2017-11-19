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
        TarefaDAO tarefaDao = new TarefaDAO();
        bool tarefaLiberada;

        public Avaliacao ()
		{
			InitializeComponent ();
            tarefaLiberada = tarefaDao.GetTarefaLiberada();
            if (!tarefaLiberada)
            {
                TarefaLib.Text = "A tarefa não liberada para avaliação!";
            }
        }

        private void Postar_Clicked(object sender, EventArgs e)
        {
            if (tarefaLiberada)
            {
                tarefaPostadaDao.PostarComentario(Comentario.Text);
                tarefaPostadaDao.PostarNotas(Convert.ToDecimal(LbNota.Text));
            }
        }

        private void StNota_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            LbNota.Text = e.NewValue.ToString();
        }
    }
}