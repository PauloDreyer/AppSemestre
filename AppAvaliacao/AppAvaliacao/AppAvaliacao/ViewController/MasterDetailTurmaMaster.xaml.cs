using AppAvaliacao.Model;
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

namespace AppAvaliacao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailTurmaMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailTurmaMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailTurmaMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailTurmaMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailTurmaMenuItem> MenuItems { get; set; }
            
            public MasterDetailTurmaMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailTurmaMenuItem>(new[]
                {
                    new MasterDetailTurmaMenuItem { Id = 0, Icon = "home.png", Title = "Home", TargetType = typeof(MasterDetailProfessor)},
                    new MasterDetailTurmaMenuItem { Id = 1, Icon = "home.png", Title = "Alunos", TargetType = typeof(NovaTurma)},
                    new MasterDetailTurmaMenuItem { Id = 2, Icon = "home.png", Title = "Tarefas", TargetType = typeof(NovaTarefa)},
                    new MasterDetailTurmaMenuItem { Id = 3, Icon = "home.png", Title = "Notas", TargetType = typeof(MasterDetailProfessor)},
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