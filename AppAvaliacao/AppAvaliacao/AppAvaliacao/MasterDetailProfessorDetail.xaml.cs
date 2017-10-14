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
    public partial class MasterDetailProfessorDetail : ContentPage
    {
        private ConMySql conexao;
        private string error;

        public MasterDetailProfessorDetail()
        {
            InitializeComponent();
            /*
            conexao = new ConMySql();
            if (conexao.TryConnection(out error))
            {
                conexao.CarregaTurmas();
            }
            */
        }
    }
}