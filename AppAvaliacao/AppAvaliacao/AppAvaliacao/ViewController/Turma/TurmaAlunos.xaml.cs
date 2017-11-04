using AppAvaliacao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao.ViewController.Turma
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TurmaAlunos : ContentPage
	{
        private TurmaDAO turmaDAO = new TurmaDAO();

        public TurmaAlunos ()
		{
			InitializeComponent ();
            lvTurmaAlunos.ItemsSource = turmaDAO.CarregaAlunos();

        }

        private void LvTurmaAlunos_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (ListaTurmas)e.SelectedItem;
            /*
            tarefa.Id = Convert.ToInt32(itemSelected.Id);
            
            if (usuario.Tipo.Equals("P"))
            {
                Navigation.PushAsync(new MasterDetailTarefaProfessor());
            }
            else
            {
                Navigation.PushAsync(new MasterDetailTarefaProfessor());
            }
            */
        }
    }
}