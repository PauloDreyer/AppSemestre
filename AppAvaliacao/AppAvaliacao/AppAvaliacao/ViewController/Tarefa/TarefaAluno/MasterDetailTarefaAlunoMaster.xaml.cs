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

namespace AppAvaliacao.ViewController.Tarefa.TarefaAluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailTarefaAlunoMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailTarefaAlunoMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailTarefaAlunoMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailTarefaAlunoMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailTarefaAlunoMenuItem> MenuItems { get; set; }
            
            public MasterDetailTarefaAlunoMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailTarefaAlunoMenuItem>(new[]
                {
                    new MasterDetailTarefaAlunoMenuItem { Id = 0, Icon = "home.png", Title = "Home", TargetType = typeof(MasterDetailTarefaAluno)},
                    new MasterDetailTarefaAlunoMenuItem { Id = 1, Icon = "home.png", Title = "Postar/Alterar Tarefa", TargetType = typeof(PostarTarefa)},
                    new MasterDetailTarefaAlunoMenuItem { Id = 2, Icon = "home.png", Title = "Participar da Tarefa", TargetType = typeof(ParticiparTarefa)},
                    new MasterDetailTarefaAlunoMenuItem { Id = 3, Icon = "home.png", Title = "Avaliar Tarefas", TargetType = typeof(TarefasPostadasAlunos)},
                    new MasterDetailTarefaAlunoMenuItem { Id = 4, Icon = "home.png", Title = "Notas", TargetType = typeof(NotasTarefasGrupo)},
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