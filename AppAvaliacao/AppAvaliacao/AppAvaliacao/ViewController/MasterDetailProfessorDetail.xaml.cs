﻿using AppAvaliacao.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
       // private UsuarioDAO usuarioDAO = new UsuarioDAO();
        private TurmaDAO turmaDAO = new TurmaDAO();

        public MasterDetailProfessorDetail()
        {
            InitializeComponent();
            lvTurmas.ItemsSource = turmaDAO.CarregaTurmas();
        }

        private void LvTurmas_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (ListaTurmas)e.SelectedItem;
            Navigation.PushAsync(new MasterDetailTurma());
        }

    }
}