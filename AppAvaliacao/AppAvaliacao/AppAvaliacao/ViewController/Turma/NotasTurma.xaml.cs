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
        private Usuario usuario = Usuario.Instancia;

        public NotasTurma ()
		{
			InitializeComponent ();
            if (usuario.Tipo.Equals("P"))
            {
                LabelNota.Text = "Alunos/Notas";
                LvNotasTurmas.ItemsSource = turmaDao.CarregaNotasTurma();
            }
            else
            {
                LabelNota.Text = "Nota";
                LvNotasTurmas.ItemsSource = turmaDao.CarregaNotasAluno();
            }
		}
	}
}