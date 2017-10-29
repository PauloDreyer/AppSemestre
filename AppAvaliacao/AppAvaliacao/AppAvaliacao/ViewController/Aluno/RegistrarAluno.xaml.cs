﻿using AppAvaliacao.Model;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAvaliacao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarAluno : ContentPage
    {
        private UsuarioDAO usuarioDAO = new UsuarioDAO();
        private string p_nome;
        private int p_matricula;
        private string p_email;
        private string p_senha;
        private string p_tipo = "A";

        public RegistrarAluno()
        {
            InitializeComponent();
        }

        async void onClickCriar(object sender, EventArgs e)
        {
            p_nome = this.nome.Text;
            p_matricula = Convert.ToInt32(this.matricula.Text);
            p_email = this.email.Text;
            p_senha = this.senha.Text;

            if (usuarioDAO.Inserir(p_nome, p_matricula, p_email, p_senha, p_tipo))
            {
                Console.WriteLine("Usuário Cadastrado!");
            }
            else
            {
                Console.WriteLine("Erro ao cadastrar usuário!");
            }
            await Navigation.PushAsync(new Login());
        }
        
    }
}