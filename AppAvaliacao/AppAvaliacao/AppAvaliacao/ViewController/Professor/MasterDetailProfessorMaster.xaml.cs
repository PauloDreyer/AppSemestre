using AppAvaliacao.ViewController.Professor;
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
    public partial class MasterDetailProfessorMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailProfessorMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailProfessorMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailProfessorMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailProfessorMenuItem> MenuItems { get; set; }
            
            public MasterDetailProfessorMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailProfessorMenuItem>(new[]
                {
                    new MasterDetailProfessorMenuItem { Id = 0, Icon = "home.png", Title = "Home", TargetType = typeof(MasterDetailProfessor)},
                    new MasterDetailProfessorMenuItem { Id = 1, Icon = "Icon.png", Title = "Cadastar Turma", TargetType = typeof(NovaTurma)},
                    new MasterDetailProfessorMenuItem { Id = 2, Icon = "home.png", Title = "Meus Dados", TargetType = typeof(MeusDadosProfessor)},
                    new MasterDetailProfessorMenuItem { Id = 3, Icon = "home.png", Title = "Sair" },
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