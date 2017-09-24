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
                    new MasterDetailProfessorMenuItem { Id = 0, Title = "Turmas", TargetType = typeof(Turma)},
                    new MasterDetailProfessorMenuItem { Id = 1, Title = "Alunos", TargetType = typeof(TipoUser)},
                    new MasterDetailProfessorMenuItem { Id = 2, Title = "Page 3" },
                    new MasterDetailProfessorMenuItem { Id = 3, Title = "Page 4" },
                    new MasterDetailProfessorMenuItem { Id = 4, Title = "Page 5" },
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