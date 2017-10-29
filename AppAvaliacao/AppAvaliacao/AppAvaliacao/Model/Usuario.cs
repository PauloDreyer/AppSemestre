using System;
using System.Collections.Generic;
using System.Text;

namespace AppAvaliacao.Model
{
    class Usuario
    {
        private string id;
        private string nome;
        private string matricula;
        private string senha;
        private string email;
        private string tipo;
        private static Usuario instancia;

        private Usuario() { }

        public static Usuario Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new Usuario();
                }
                return instancia;
            }
        }

        public string Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public string Senha { get => senha; set => senha = value; }
    }
}
