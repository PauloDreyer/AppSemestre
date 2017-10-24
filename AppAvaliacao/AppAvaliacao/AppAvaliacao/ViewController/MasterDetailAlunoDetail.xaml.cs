using AppAvaliacao.Model;
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
    public partial class MasterDetailAlunoDetail : ContentPage
    {
        private TurmaDAO turmaDAO = new TurmaDAO();
        private Turma turma = Turma.Instancia;

        public MasterDetailAlunoDetail()
        {
            InitializeComponent();
            lvTurmas.ItemsSource = turmaDAO.CarregaTurmas();
        }

        private void LvTurmas_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (ListaTurmas)e.SelectedItem;
            turma.Id = Convert.ToInt32(itemSelected.Id);
            turma.Id_inscricao = Convert.ToInt32(itemSelected.IdInscricao);

            Navigation.PushAsync(new MasterDetailTurma());
        }
    }
}