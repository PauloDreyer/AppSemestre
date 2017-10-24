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
    public partial class MasterDetailAlunoMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailAlunoMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailAlunoMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailAlunoMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailAlunoMenuItem> MenuItems { get; set; }
            
            public MasterDetailAlunoMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailAlunoMenuItem>(new[]
                {
                    new MasterDetailAlunoMenuItem { Id = 0, Icon = "home.png", Title = "Home", TargetType = typeof(MasterDetailAluno)},
                    new MasterDetailAlunoMenuItem { Id = 1, Icon = "Icon.png", Title = "Inscrição Turma", TargetType = typeof(InscricaoTurma)},
                    new MasterDetailAlunoMenuItem { Id = 2, Icon = "home.png", Title = "Meus Dados", TargetType = typeof(TipoUser)},
                    new MasterDetailAlunoMenuItem { Id = 3, Icon = "home.png", Title = "Sair" },
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