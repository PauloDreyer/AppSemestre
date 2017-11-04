using AppAvaliacao.ViewController.Tarefa.TarefaProfessor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao.ViewController.Tarefa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailTarefaProfessorMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailTarefaProfessorMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailTarefaProfessorMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailTarefaProfessorMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailTarefaProfessorMenuItem> MenuItems { get; set; }
            
            public MasterDetailTarefaProfessorMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailTarefaProfessorMenuItem>(new[]
                {
                    new MasterDetailTarefaProfessorMenuItem { Id = 0, Icon = "home.png", Title = "Home", TargetType = typeof(MasterDetailTarefaProfessor)},
                    //new MasterDetailTarefaProfessorMenuItem { Id = 1, Icon = "home.png", Title = "Editar Tarefa", TargetType = typeof(TurmaAlunos)},
                    new MasterDetailTarefaProfessorMenuItem { Id = 2, Icon = "home.png", Title = "Liberar/Bloquear Avaliação", TargetType = typeof(LiberarAvaliacao)},
                    new MasterDetailTarefaProfessorMenuItem { Id = 3, Icon = "home.png", Title = "Notas", TargetType = typeof(MasterDetailProfessor)},
                    new MasterDetailTarefaProfessorMenuItem { Id = 4, Icon = "home.png", Title = "Código de Inscrição", TargetType = typeof(ExibirCodInsc)},
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}