using AppAvaliacao.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailProfessorDetail : ContentPage
    {
        private ConMySql conexao;
        private string error;

        public MasterDetailProfessorDetail()
        {
            //List<ListaTurmas> turmas = new List<ListaTurmas>();
            ObservableCollection<ListaTurmas> turmas = new ObservableCollection<ListaTurmas>();
            InitializeComponent();
           
            conexao = new ConMySql();
            if (conexao.TryConnection(out error))
            {
                turmas =  conexao.CarregaTurmas();
            }
            else
            {
                DisplayAlert("Error: ", error, "C");
            }

            lvTurmas.ItemsSource = turmas;

        }

        private void LvTurmas_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (ListaTurmas)e.SelectedItem;
            Console.WriteLine(itemSelected.Nome);
            Navigation.PushAsync(new MasterDetailTurma());
        }

    }
}