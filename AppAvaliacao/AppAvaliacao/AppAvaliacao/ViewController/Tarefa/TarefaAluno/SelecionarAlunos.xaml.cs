using AppAvaliacao.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao.ViewController.Tarefa.TarefaAluno
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelecionarAlunos : ContentPage
	{
        ObservableCollection<int> ListarAlunos = new ObservableCollection<int>();
        TurmaDAO turmaDao = new TurmaDAO();
        string v;
        public SelecionarAlunos ()
		{
			InitializeComponent ();
            LvSelecaoAlunos.ItemsSource = turmaDao.CarregaAlunos();

        }

        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            if(e.Value)
            {  
                 ListarAlunos.Remove(Convert.ToInt32(LvSelecaoAlunos.Id.ToString()));
            }
            else
            {
                if (ListarAlunos.Contains(Convert.ToInt32(LvSelecaoAlunos.Id.ToString())))
                {
                    ListarAlunos.Remove(Convert.ToInt32(LvSelecaoAlunos.Id.ToString()));
                }
            }
            
        }

        private void LvSelecaoAlunos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void Ok_Clicked(object sender, EventArgs e)
        {

        }
    }
}