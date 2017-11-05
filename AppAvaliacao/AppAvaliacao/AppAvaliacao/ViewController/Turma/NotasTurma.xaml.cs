using AppAvaliacao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao.ViewController.Turma
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotasTurma : ContentPage
	{
        private TurmaDAO turmaDao = new TurmaDAO();

        public NotasTurma ()
		{
			InitializeComponent ();
            LvNotasTurmas.ItemsSource = turmaDao.CarregaNotasTurma();
		}
	}
}