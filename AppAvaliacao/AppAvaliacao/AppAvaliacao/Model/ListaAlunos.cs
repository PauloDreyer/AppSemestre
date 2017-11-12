using System;
using System.Collections.Generic;
using System.Text;

namespace AppAvaliacao.Model
{
    class ListaAlunos
    {
        private int id;
        private string nome;
        private int matricula;
        private string email;
        private string nota;
        private bool selecionado;
        /*
        private static ListaAlunos instancia;

        public ListaAlunos()
        {

        }

        public static ListaAlunos Instancia{
            get
            {
                if(instancia == null)
                {
                    instancia = new ListaAlunos();
                }

                return instancia;
            }
        }
        */
        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public int Matricula { get => matricula; set => matricula = value; }
        public string Email { get => email; set => email = value; }
        public string Nota { get => nota; set => nota = value; }
        public bool Selecionado { get => selecionado; set => selecionado = value; }
    }
}
