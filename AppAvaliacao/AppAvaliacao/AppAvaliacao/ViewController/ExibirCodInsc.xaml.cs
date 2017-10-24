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
	public partial class ExibirCodInsc : ContentPage
	{
        private Turma turma = Turma.Instancia;

        public ExibirCodInsc ()
		{
			InitializeComponent ();
            idInscricao.Text = Convert.ToString(turma.Id_inscricao);
        }
	}
}