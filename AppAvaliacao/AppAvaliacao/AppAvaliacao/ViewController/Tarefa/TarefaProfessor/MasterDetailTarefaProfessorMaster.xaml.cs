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
                    new MasterDetailTarefaProfessorMenuItem { Id = 0, Title = "Page 1" },
                    new MasterDetailTarefaProfessorMenuItem { Id = 1, Title = "Page 2" },
                    new MasterDetailTarefaProfessorMenuItem { Id = 2, Title = "Page 3" },
                    new MasterDetailTarefaProfessorMenuItem { Id = 3, Title = "Page 4" },
                    new MasterDetailTarefaProfessorMenuItem { Id = 4, Title = "Page 5" },
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